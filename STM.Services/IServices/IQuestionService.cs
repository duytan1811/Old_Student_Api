namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Questions;

    public interface IQuestionService
    {
        Task<IQueryable<QuestionDto>> Search(QuestionSearchDto dto);

        Task<QuestionDto?> FindById(Guid id);

        Task<string> Create(QuestionSaveDto dto);

        Task<string> Update(QuestionSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
