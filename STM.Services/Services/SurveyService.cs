namespace STM.Services.Services
{
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
