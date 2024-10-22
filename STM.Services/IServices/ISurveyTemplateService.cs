namespace STM.Services.IServices
{
    using STM.DataTranferObjects.SurveyTemplates;

    public interface ISurveyTemplateService
    {
        Task<IQueryable<SurveyTemplateDto>> Search(SurveyTemplateSearchDto dto);

        Task<SurveyTemplateDto?> FindById(Guid id);

        Task<string> Create(SurveyTemplateSaveDto dto);

        Task<string> Update(SurveyTemplateSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
