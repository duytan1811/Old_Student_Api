namespace STM.Services.Services
{
    using System.Linq;
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Questions;
    using STM.DataTranferObjects.Surveys;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SurveyService(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<IQueryable<SurveyDto>> Search(SurveySearchDto dto)
        {
            var querySurvey = await this._unitOfWork.GetRepositoryReadOnlyAsync<Survey>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var nameSearch = dto.Name.Trim().ToLower();
                querySurvey = querySurvey.Where(x => x.Name.ToLower().Contains(nameSearch));
            }

            if (dto.StartDate.HasValue)
            {
                querySurvey = querySurvey.Where(x => x.StartDate >= dto.StartDate);
            }

            if (dto.EndDate.HasValue)
            {
                querySurvey = querySurvey.Where(x => x.EndDate <= dto.EndDate);
            }

            if (dto.Status.HasValue)
            {
                querySurvey = querySurvey.Where(x => x.Status == dto.Status);
            }

            var query = querySurvey.Include(x => x.SurveyResults).OrderBy(x => x.CreatedAt).Select(x => new SurveyDto
            {
                Id = x.Id,
                Name = x.Name,
                EndDate = x.EndDate,
                StartDate = x.StartDate,
                QuestionIds = !string.IsNullOrEmpty(x.QuestionIds) ? JsonConvert.DeserializeObject<List<Guid>>(x.QuestionIds) : null,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                IsSurveyed = x.SurveyResults.Any(i => i.CreatedById == dto.CurrentUserId),
                CountSurveyed = x.SurveyResults.GroupBy(x => x.CreatedById).Count(),
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                ColumnNames.IsSurveyed => dto.Ascending ? query.OrderBy(x => x.IsSurveyed).ThenBy(x => x.EndDate)
                : query.OrderByDescending(x => x.IsSurveyed).ThenByDescending(x => x.EndDate),
                _ => query,
            };
        }

        public async Task<IQueryable<SurveyResultDto>> SearchServeyResult(SurveyResultSearchDto dto)
        {
            var querySurveyRS = await this._unitOfWork.GetRepositoryReadOnlyAsync<SurveyResult>().QueryAll();
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();

            queryStudent = queryStudent.Include(x => x.User);

            if (dto.SurveyId.HasValue)
            {
                querySurveyRS = querySurveyRS.Where(x => x.SurveyId == dto.SurveyId);
            }

            if (dto.Date.HasValue)
            {
                querySurveyRS = querySurveyRS.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Date == dto.Date.Value.Date);
            }

            if (!string.IsNullOrEmpty(dto.FullName))
            {
                var nameSearch = dto.FullName.Trim().ToLower();
                queryStudent = queryStudent.Where(x => x.FullName.ToLower().Contains(nameSearch));
            }

            var userIds = queryStudent.GroupBy(x => x.UserId).Select(x => x.Key).ToList();

            var query = (from ss in querySurveyRS
                         join u in queryUser on ss.CreatedById equals u.Id
                         join s in queryStudent on u.Id equals s.UserId into us
                         from res in us.DefaultIfEmpty()
                         where ss.CreatedById.HasValue && userIds.Contains(ss.CreatedById)
                         select new
                         {
                             CreatedById = ss.CreatedById.Value,
                             SurveyId = ss.SurveyId,
                             FullName = u.IsAdmin ? "Admin" : res.FullName,
                             CreatedAt = ss.CreatedAt,
                         }).GroupBy(x => new { x.CreatedById, x.SurveyId, x.FullName, x.CreatedAt.Value.Date })
                         .Select(x => new SurveyResultDto
                         {
                             CreatedById = x.Key.CreatedById,
                             SurveyId = x.Key.SurveyId,
                             FullName = x.Key.FullName,
                             CreatedAt = x.Key.Date,
                         });

            return dto.Column switch
            {
                _ => query,
            };
        }

        public async Task<SurveyDto?> FindById(Guid id)
        {
            var querySurvey = await this._unitOfWork.GetRepositoryReadOnlyAsync<Survey>().QueryAll();
            var queryQuestion = await this._unitOfWork.GetRepositoryReadOnlyAsync<Question>().QueryAll();

            var survey = querySurvey.FirstOrDefault(i => i.Id == id);

            if (survey == null)
            {
                return null;
            }

            var result = this._mapper.Map<SurveyDto>(survey);

            var questions = queryQuestion.Where(x => result.QuestionIds.Contains(x.Id))
                .Select(x => new QuestionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsComment = x.IsComment,
                }).ToList();

            result.Questions = questions;

            return result;
        }

        public async Task<SurveyResultDetailDto?> GetSurveyDetail(Guid surveyId, Guid userId)
        {
            var querySurvey = await this._unitOfWork.GetRepositoryReadOnlyAsync<Survey>().QueryAll();
            var querySurveyRS = await this._unitOfWork.GetRepositoryReadOnlyAsync<SurveyResult>().QueryAll();
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();

            var survey = querySurvey.FirstOrDefault(i => i.Id == surveyId);

            if (survey == null)
            {
                return null;
            }

            var user = queryUser.Include(x => x.Student).FirstOrDefault(i => i.Id == userId);

            var surveyRS = querySurveyRS.Include(x => x.Question)
                .Where(x => x.SurveyId == survey.Id && x.CreatedById == user.Id).ToList();
            var result = new SurveyResultDetailDto();
            result.CreatedByName = user.IsAdmin ? "Admin" : user.Student.FullName;

            result.Items = this._mapper.Map<List<SurveyResultDetailItemDto>>(surveyRS);

            return result;
        }

        public async Task<string> Create(SurveySaveDto dto)
        {
            var surveyRep = this._unitOfWork.GetRepositoryAsync<Survey>();

            var newSurvey = new Survey
            {
                Name = dto.Name,
                QuestionIds = dto.QuestionIds.Any() ? JsonConvert.SerializeObject(dto.QuestionIds) : null,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            DateTime startDate;
            if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
            {
                newSurvey.StartDate = startDate;
            }

            DateTime endDate;
            if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
            {
                newSurvey.EndDate = endDate;
            }

            await surveyRep.Add(newSurvey);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.Survey);
        }

        public async Task<string> Update(SurveySaveDto dto)
        {
            var surveyRep = this._unitOfWork.GetRepositoryAsync<Survey>();

            var survey = await surveyRep.Single(i => i.Id == dto.Id);

            if (survey == null)
            {
                return Messages.NotFound;
            }

            survey.Name = dto.Name;
            survey.Status = dto.Status;
            survey.QuestionIds = dto.QuestionIds.Any() ? JsonConvert.SerializeObject(dto.QuestionIds) : null;

            DateTime startDate;
            if (!string.IsNullOrEmpty(dto.StartDateFormat) && DateTime.TryParse(dto.StartDateFormat, out startDate))
            {
                survey.StartDate = startDate;
            }

            DateTime endDate;
            if (!string.IsNullOrEmpty(dto.EndDateFormat) && DateTime.TryParse(dto.EndDateFormat, out endDate))
            {
                survey.EndDate = endDate;
            }

            await surveyRep.Update(survey);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.Survey);
        }

        public async Task<string> Delete(Guid id)
        {
            var surveyRep = this._unitOfWork.GetRepositoryAsync<Survey>();
            var querySurvey = await this._unitOfWork.GetRepositoryReadOnlyAsync<SurveyResult>().QueryAll();

            var survey = await surveyRep.Single(i => i.Id == id);

            if (survey == null)
            {
                return Messages.NotFound;
            }

            var isExistsSurveyRS = querySurvey.Any();
            if (isExistsSurveyRS)
            {
                return string.Format(Messages.CannotDelete, GlobalConstants.Menu.Survey);
            }

            await surveyRep.Delete(survey);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Survey);
        }

        public async Task<string> SaveSurveryResult(Guid id, SurveyResultSaveDto dto)
        {
            var surveyRep = this._unitOfWork.GetRepositoryAsync<Survey>();
            var surveyRsRep = this._unitOfWork.GetRepositoryAsync<SurveyResult>();

            var survey = await surveyRep.Single(i => i.Id == id);

            if (survey == null)
            {
                return Messages.NotFound;
            }

            var newSurveyRs = dto.Questions.Select(x => new SurveyResult
            {
                Comment = x.Comment,
                QuestionId = x.QuestionId,
                Point = x.Point,
                SurveyId = id,
            });

            await surveyRsRep.Add(newSurveyRs);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.Survey);
        }
    }
}
