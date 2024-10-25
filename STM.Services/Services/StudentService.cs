namespace STM.Services.Services
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Students;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IQueryable<StudentDto>> Search(StudentSearchDto dto)
        {
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();

            queryStudent = queryStudent.Include(x => x.StudentAchievements).Include(x => x.Contributes);
            if (!string.IsNullOrEmpty(dto.FullName))
            {
                var nameSearch = dto.FullName.Trim().ToLower();
                queryStudent = queryStudent.Where(x => x.FullName.ToLower().Contains(nameSearch));
            }

            if (!string.IsNullOrEmpty(dto.MajorId))
            {
                queryStudent = queryStudent.Where(x => x.MajorId == Guid.Parse(dto.MajorId));
            }

            if (dto.SchoolYear.HasValue)
            {
                queryStudent = queryStudent.Where(x => x.SchoolYear == dto.SchoolYear);
            }

            if (dto.YearOfGraduation.HasValue)
            {
                queryStudent = queryStudent.Where(x => x.YearOfGraduation == dto.YearOfGraduation);
            }

            if (!string.IsNullOrEmpty(dto.Phone))
            {
                queryStudent = queryStudent.Where(x => x.Phone.ToLower() == dto.Phone.ToLower());
            }

            if (dto.Status.HasValue)
            {
                queryStudent = queryStudent.Where(x => x.Status == dto.Status);
            }

            var query = queryStudent.OrderBy(x => x.CreatedAt).Select(x => new StudentDto
            {
                Id = x.Id,
                FullName = x.FullName,
                Phone = x.Phone,
                MajorName = x.MajorId.HasValue ? x.Major.Name : string.Empty,
                SchoolYear = x.SchoolYear,
                YearOfGraduation = x.YearOfGraduation,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                CountArchievement = x.StudentAchievements.Count(),
                CountContribute = x.Contributes.Count(),
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<StudentDto?> FindById(Guid id)
        {
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();
            var student = queryStudent.Include(x => x.Major).Include(x => x.StudentAchievements).Include(x => x.Contributes).FirstOrDefault(i => i.Id == id);

            if (student == null)
            {
                return null;
            }

            var result = this._mapper.Map<StudentDto>(student);
            result.CountArchievement = student.StudentAchievements.Count;

            return result;
        }

        public async Task<List<StudentContributeDto>> GetContributes(Guid id)
        {
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();
            var student = queryStudent.Include(x => x.Major).Include(x => x.StudentAchievements).Include(x => x.Contributes).FirstOrDefault(i => i.Id == id);
            var result = new List<StudentContributeDto>();

            if (student == null)
            {
                return result;
            }

            if (student.Contributes.Count > 0)
            {
                result = student.Contributes.Select(x => new StudentContributeDto
                {
                    Type = x.Type,
                    Amount = x.Amount,
                    Detail = x.Detail,
                }).ToList();
            }

            return result;
        }

        public async Task<string> Create(StudentSaveDto dto)
        {
            var studentRep = this._unitOfWork.GetRepositoryAsync<Student>();

            var newStudent = new Student
            {
                FullName = dto.FullName,
                Phone = dto.Phone,
                Email = dto.Email,
                SchoolYear = dto.SchoolYear,
                Gender = dto.Gender,
                YearOfGraduation = dto.YearOfGraduation,
                MajorId = dto.MajorId,
                CurrentCompany = dto.CurrentCompany,
                JobTitle = dto.JobTitle,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            DateTime birthday;
            if (!string.IsNullOrEmpty(dto.BirthdayFormat) && DateTime.TryParse(dto.BirthdayFormat, out birthday))
            {
                newStudent.Birthday = birthday;
            }

            await studentRep.Add(newStudent);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Student);
        }

        public async Task<string> Update(StudentSaveDto dto)
        {
            var studentRep = this._unitOfWork.GetRepositoryAsync<Student>();

            var student = await studentRep.Single(i => i.Id == dto.Id);

            if (student == null)
            {
                return Messages.NotFound;
            }

            student.FullName = dto.FullName;
            student.Phone = dto.Phone;
            student.Email = dto.Email;
            student.SchoolYear = dto.SchoolYear;
            student.Gender = dto.Gender;
            student.YearOfGraduation = dto.YearOfGraduation;
            student.MajorId = dto.MajorId;
            student.CurrentCompany = dto.CurrentCompany;
            student.Status = dto.Status;
            student.JobTitle = dto.JobTitle;

            DateTime birthday;
            if (!string.IsNullOrEmpty(dto.BirthdayFormat) && DateTime.TryParse(dto.BirthdayFormat, out birthday))
            {
                student.Birthday = birthday;
            }

            await studentRep.Update(student);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Student);
        }

        public async Task<string> Delete(Guid id)
        {
            var userRep = this._unitOfWork.GetRepositoryAsync<User>();
            var studentRep = this._unitOfWork.GetRepositoryAsync<Student>();
            var studentACRep = this._unitOfWork.GetRepositoryAsync<StudentAchievement>();
            var student = await studentRep.Single(i => i.Id == id);

            if (student == null)
            {
                return Messages.NotFound;
            }

            var studentACs = await studentACRep.QueryCondition(x => x.StudentId == student.Id);
            var user = await userRep.Single(x => x.Id == student.UserId);

            await studentACRep.Delete(studentACs.ToList());
            await studentRep.Delete(student);
            await userRep.Delete(user);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Student);
        }
    }
}
