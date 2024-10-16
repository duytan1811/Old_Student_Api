namespace STM.Services.Services
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.DataTranferObjects.Users;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(
            IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
        }

        public async Task<IQueryable<UserDto>> Search(UserSearchDto dto)
        {
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();
            queryUser = queryUser.Include(x => x.UserRoles).Include(x => x.Student).ThenInclude(x => x.Major).Where(x => !x.IsAdmin);

            if (!string.IsNullOrEmpty(dto.UserName))
            {
                queryUser = queryUser.Where(x => x.UserName.Trim().ToLower().Contains(dto.UserName.Trim().ToLower()));
            }

            if (dto.ExistsIds.Any())
            {
                queryUser = queryUser.Where(x => !dto.ExistsIds.Contains(x.Id));
            }

            if (!string.IsNullOrEmpty(dto.Email))
            {
                queryUser = queryUser.Where(x => x.Email.Trim().ToLower().Contains(dto.Email.Trim().ToLower()));
            }

            if (dto.IsTeacher)
            {
                queryUser = queryUser.Where(x => x.IsTeacher);
            }

            if (dto.IsStudent)
            {
                queryUser = queryUser.Where(x => !x.IsTeacher);
            }

            if (dto.Status.HasValue)
            {
                queryUser = queryUser.Where(x => x.Status == dto.Status);
            }

            var query = queryUser.Select(x => new UserDto
            {
                Id = x.Id,
                UserName = x.UserName,
                FullName = x.Student != null ? x.Student.FullName : null,
                Email = x.Email,
                IsTeacher = x.IsTeacher,
                Status = x.Status,
                MajorName = x.Student.Major.Name,
                SchoolYear = x.Student.SchoolYear,
                YearOfGraduation = x.Student.YearOfGraduation,
                CurrentCompany = x.Student.CurrentCompany,
                JobTitle = x.Student.JobTitle,
                Phone = x.Student.Phone,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<UserDto> FindById(Guid id)
        {
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();

            var user = queryUser.Include(x => x.UserRoles).Include(x => x.Student).Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return new UserDto();
            }

            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.Student != null ? user.Student.FullName : null,
                Email = user.Email,
                IsTeacher = user.IsTeacher,
                Status = user.Status,
                UserType = user.UserType,
            };
        }

        public async Task<ActionStatusEnum> Create(UserSaveDto dto)
        {
            var statusExisted = await this.CheckUserExists(dto);
            var studentRep = this._unitOfWork.GetRepositoryAsync<Student>();

            if (statusExisted != ActionStatusEnum.Success)
            {
                return statusExisted;
            }

            if (dto.IsDefaultPassword)
            {
                dto.Password = GlobalConstants.PasswordDefault;
            }

            var newUser = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Status = StatusEnum.Active,
                CreatedAt = DateTime.Now,
                IsTeacher = dto.IsTeacher,
                UserType = dto.UserType.HasValue ? dto.UserType : UserTypeEnum.Student,
            };

            var newStudent = new Student()
            {
                FullName = dto.FullName,
                User = newUser,
            };

            await this._userManager.CreateAsync(newUser, dto.Password);
            await studentRep.Add(newStudent);
            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<ActionStatusEnum> Update(UserSaveDto dto)
        {
            var user = await this._userManager.FindByIdAsync(dto.Id.ToString());
            var studentRep = this._unitOfWork.GetRepositoryAsync<Student>();

            if (user == null)
            {
                return ActionStatusEnum.NotFound;
            }

            var student = await studentRep.Single(x => x.UserId == dto.Id);
            var statusExisted = await this.CheckUserExists(dto);

            if (statusExisted != ActionStatusEnum.Success)
            {
                return statusExisted;
            }

            user.Email = dto.Email;
            user.UpdatedAt = DateTime.Now;
            user.UserType = dto.UserType;
            user.Status = dto.Status;
            user.IsTeacher = dto.IsTeacher;

            student.FullName = dto.FullName;

            await studentRep.Update(student);
            var result = await this._userManager.UpdateAsync(user);
            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<ActionStatusEnum> Delete(Guid id)
        {
            var userRep = this._unitOfWork.GetRepositoryAsync<User>();
            var studentRep = this._unitOfWork.GetRepositoryAsync<Student>();

            var user = await userRep.Single(x => x.Id == id);
            if (user == null)
            {
                return ActionStatusEnum.NotFound;
            }

            var student = await studentRep.Single(x => x.UserId == user.Id);
            if (student != null)
            {
                await studentRep.Delete(student);
            }

            await userRep.Delete(user);
            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<MemoryStream> ExportExcel(UserSearchDto dto)
        {
            string templatePath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.TemplateFolder);
            string reportPath = Path.Combine(Environment.CurrentDirectory, GlobalConstants.ResourceFolder, GlobalConstants.ReportFolder);
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(reportPath);
            }

            string fileName = string.Format(FileNameConstants.StatisticsMember, DateTime.Now.ToString("yyyyMMddhhmmsss"));
            FileInfo newFile = new FileInfo(Path.Combine(reportPath, fileName));
            FileInfo templateFile = new FileInfo(Path.Combine(templatePath, FileNameConstants.StatisticsMemberTemplate));

            var data = (await this.Search(dto)).OrderByDescending(x => x.CreatedAt).ToList();

            using (ExcelPackage pck = new ExcelPackage(newFile, templateFile))
            {
                var row = 4;
                ExcelWorksheet sheet = pck.Workbook.Worksheets[0];
                foreach (var item in data)
                {
                    sheet.Cells[$"B{row}"].Value = row - 3;
                    sheet.Cells[$"C{row}"].Value = item.UserName;
                    sheet.Cells[$"D{row}"].Value = item.FullName;
                    sheet.Cells[$"E{row}"].Value = item.Phone;
                    sheet.Cells[$"F{row}"].Value = item.Email;
                    sheet.Cells[$"G{row}"].Value = item.SchoolYear;
                    sheet.Cells[$"H{row}"].Value = item.YearOfGraduation;
                    sheet.Cells[$"I{row}"].Value = item.MajorName;
                    sheet.Cells[$"J{row}"].Value = item.JobTitle;
                    sheet.Cells[$"K{row}"].Value = item.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue(item.Status.Value) : string.Empty;
                    row++;
                }

                ExcelHelper.RenderBorderAll(sheet, 4, 2, row - 1, 11, ExcelBorderStyle.Thin);

                sheet.Name = "BC";
                var stream = new MemoryStream();
                pck.ToStream(newFile);
                pck.SaveAs(stream);
                return stream;
            }
        }

        private async Task<ActionStatusEnum> CheckUserExists(UserSaveDto dto)
        {
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();
            if (dto.Id.HasValue)
            {
                queryUser = queryUser.Where(x => x.Id != dto.Id);
            }

            if (queryUser.Where(x => x.UserName.ToLower() == dto.UserName.Trim().ToLower()).Any())
            {
                return ActionStatusEnum.UserNameExists;
            }

            if (queryUser.Where(x => x.Email.ToLower() == dto.Email.Trim().ToLower()).Any())
            {
                return ActionStatusEnum.EmailExists;
            }

            return ActionStatusEnum.Success;
        }
    }
}
