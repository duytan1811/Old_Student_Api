namespace STM.Services.Services
{
    using Newtonsoft.Json;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.SurveyTemplates;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class SurveyTemplateService : ISurveyTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SurveyTemplateService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<SurveyTemplateDto>> Search(SurveyTemplateSearchDto dto)
        {
            var querySurveyTemplate = await this._unitOfWork.GetRepositoryReadOnlyAsync<SurveyTemplate>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var nameSearch = dto.Name.Trim().ToLower();
                querySurveyTemplate = querySurveyTemplate.Where(x => x.Name.ToLower().Contains(nameSearch));
            }

            if (dto.Status.HasValue)
            {
                querySurveyTemplate = querySurveyTemplate.Where(x => x.Status == dto.Status);
            }

            var query = querySurveyTemplate.OrderBy(x => x.CreatedAt).Select(x => new SurveyTemplateDto
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
            });

            return dto.Column switch
            {
                ColumnNames.CreatedAt => dto.Ascending ? query.OrderBy(x => x.CreatedAt) : query.OrderByDescending(x => x.CreatedAt),
                _ => query,
            };
        }

        public async Task<SurveyTemplateDto?> FindById(Guid id)
        {
            var querySurveyTemplate = await this._unitOfWork.GetRepositoryReadOnlyAsync<SurveyTemplate>().QueryAll();
            var surveyTemplate = querySurveyTemplate.FirstOrDefault(i => i.Id == id);

            if (surveyTemplate == null)
            {
                return null;
            }

            return new SurveyTemplateDto
            {
                Id = surveyTemplate.Id,
                Name = surveyTemplate.Name,
                Status = surveyTemplate.Status,
                CreatedAt = surveyTemplate.CreatedAt,
                CreatedById = surveyTemplate.CreatedById,
                UpdatedAt = surveyTemplate.UpdatedAt,
                UpdatedById = surveyTemplate.UpdatedById,
            };
        }

        public async Task<string> Create(SurveyTemplateSaveDto dto)
        {
            var surveyTemplateRep = this._unitOfWork.GetRepositoryAsync<SurveyTemplate>();

            var newSurveyTemplate = new SurveyTemplate
            {
                Name = dto.Name,
                QuestionIds = dto.QuestionIds.Any() ? JsonConvert.SerializeObject(dto.QuestionIds) : null,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active,
            };

            await surveyTemplateRep.Add(newSurveyTemplate);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.CreateSuccess, GlobalConstants.Menu.SurveyTemplate);
        }

        public async Task<string> Update(SurveyTemplateSaveDto dto)
        {
            var surveyTemplateRep = this._unitOfWork.GetRepositoryAsync<SurveyTemplate>();

            var surveyTemplate = await surveyTemplateRep.Single(i => i.Id == dto.Id);

            if (surveyTemplate == null)
            {
                return Messages.NotFound;
            }

            surveyTemplate.Name = dto.Name;
            surveyTemplate.QuestionIds = dto.QuestionIds.Any() ? JsonConvert.SerializeObject(dto.QuestionIds) : null;
            surveyTemplate.Status = dto.Status;

            await surveyTemplateRep.Update(surveyTemplate);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.UpdateSuccess, GlobalConstants.Menu.SurveyTemplate);
        }

        public async Task<string> Delete(Guid id)
        {
            var surveyTemplateRep = this._unitOfWork.GetRepositoryAsync<SurveyTemplate>();
            var querySurvey = this._unitOfWork.GetRepositoryAsync<Survey>().QueryCondition(x => x.SurveyTemplateId == id);

            var surveyTemplate = await surveyTemplateRep.Single(i => i.Id == id);

            if (surveyTemplate == null)
            {
                return Messages.NotFound;
            }

            var isExistsSurvey = (await querySurvey).Any();
            if (isExistsSurvey)
            {
                return string.Format(Messages.CannotDelete, GlobalConstants.Menu.SurveyTemplate);
            }

            await surveyTemplateRep.Delete(surveyTemplate);
            await this._unitOfWork.SaveChangesAsync();

            return string.Format(Messages.DeleteSuccess, GlobalConstants.Menu.SurveyTemplate);
        }
    }
}
