namespace STM.Services.Services
{
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.StudentAchievements;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class StudentAchievementService : IStudentAchievementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentAchievementService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<StudentAchievementDto>> Search(StudentAchievementSearchDto dto)
        {
            var queryStudentAchievement = await this._unitOfWork.GetRepositoryReadOnlyAsync<StudentAchievement>().QueryAll();

            if (dto.StudentId.HasValue)
            {
                queryStudentAchievement = queryStudentAchievement.Where(x => x.StudentId == dto.StudentId);
            }

            if (dto.FromDate.HasValue)
            {
                queryStudentAchievement = queryStudentAchievement.Where(x => x.FromDate == dto.FromDate);
            }

            if (dto.ToDate.HasValue)
            {
                queryStudentAchievement = queryStudentAchievement.Where(x => x.ToDate == dto.ToDate);
            }

            if (dto.Status.HasValue)
            {
                queryStudentAchievement = queryStudentAchievement.Where(x => x.Status == dto.Status);
            }

            var query = queryStudentAchievement.Select(x => new StudentAchievementDto
            {
                Id = x.Id,
                Name = x.Name,
                FromDate = x.FromDate,
                ToDate = x.ToDate,
                Description = x.Description,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                ColumnNames.EndDate => dto.Ascending ? query.OrderBy(x => x.ToDate) : query.OrderByDescending(x => x.ToDate),
                _ => query,
            };
        }

        public async Task<StudentAchievementDto?> FindById(Guid id)
        {
            var queryStudentAchievement = await this._unitOfWork.GetRepositoryReadOnlyAsync<StudentAchievement>().QueryAll();
            var studentAchievement = queryStudentAchievement.FirstOrDefault(i => i.Id == id);

            if (studentAchievement == null)
            {
                return null;
            }

            return new StudentAchievementDto
            {
                Id = studentAchievement.Id,
                Name = studentAchievement.Name,
                Status = studentAchievement.Status,
                Description = studentAchievement.Description,
                FromDate = studentAchievement.FromDate,
                ToDate = studentAchievement.ToDate,
            };
        }

        public async Task<string> Create(StudentAchievementSaveDto dto)
        {
            var studentAchievementRep = this._unitOfWork.GetRepositoryAsync<StudentAchievement>();

            var newStudentAchievement = new StudentAchievement
            {
                StudentId = dto.StudentId,
                Name = dto.Name,
                Description = dto.Description,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            DateTime fromDate;
            if (!string.IsNullOrEmpty(dto.FromDateFormat) && DateTime.TryParse(dto.FromDateFormat, out fromDate))
            {
                newStudentAchievement.FromDate = fromDate;
            }

            DateTime toDate;
            if (!string.IsNullOrEmpty(dto.ToDateFormat) && DateTime.TryParse(dto.ToDateFormat, out toDate))
            {
                newStudentAchievement.ToDate = toDate;
            }

            await studentAchievementRep.Add(newStudentAchievement);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Achievement);
        }

        public async Task<string> Update(StudentAchievementSaveDto dto)
        {
            var studentAchievementRep = this._unitOfWork.GetRepositoryAsync<StudentAchievement>();

            var studentAchievement = await studentAchievementRep.Single(i => i.Id == dto.Id);

            if (studentAchievement == null)
            {
                return Messages.NotFound;
            }

            studentAchievement.Name = dto.Name;
            studentAchievement.Description = dto.Description;
            studentAchievement.Status = dto.Status;

            DateTime fromDate;
            if (!string.IsNullOrEmpty(dto.FromDateFormat) && DateTime.TryParse(dto.FromDateFormat, out fromDate))
            {
                studentAchievement.FromDate = fromDate;
            }

            DateTime toDate;
            if (!string.IsNullOrEmpty(dto.ToDateFormat) && DateTime.TryParse(dto.ToDateFormat, out toDate))
            {
                studentAchievement.ToDate = toDate;
            }

            await studentAchievementRep.Update(studentAchievement);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Achievement);
        }

        public async Task<string> Delete(Guid id)
        {
            var studentAchievementRep = this._unitOfWork.GetRepositoryAsync<StudentAchievement>();
            var studentAchievement = await studentAchievementRep.Single(i => i.Id == id);

            if (studentAchievement == null)
            {
                return Messages.NotFound;
            }

            await studentAchievementRep.Delete(studentAchievement);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Achievement);
        }
    }
}
