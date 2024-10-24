namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Surveys;

    public interface ISurveyService
    {
        Task<IQueryable<SurveyDto>> Search(SurveySearchDto dto);

        Task<IQueryable<SurveyResultDto>> SearchServeyResult(SurveyResultSearchDto dto);

        Task<SurveyDto?> FindById(Guid id);

        Task<SurveyResultDetailDto?> GetSurveyDetail(Guid surveyId, Guid userId);

        Task<string> Create(SurveySaveDto dto);

        Task<string> Update(SurveySaveDto dto);

        Task<string> Delete(Guid id);

        Task<string> SaveSurveryResult(Guid id, SurveyResultSaveDto dto);
    }
}
