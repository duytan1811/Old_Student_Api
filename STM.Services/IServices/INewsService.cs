namespace STM.Services.IServices
{
    using STM.DataTranferObjects.News;

    public interface INewsService
    {
        Task<IQueryable<NewsDto>> Search(NewsSearchDto dto);

        Task<NewsDto?> FindById(Guid id, Guid currenUserId);

        Task<IQueryable<CommentDto>?> GetComments(CommentSearchDto dto);

        Task<string> Create(NewsSaveDto dto);

        Task<string> Update(NewsSaveDto dto);

        Task<string> Like(Guid newId, Guid userId);

        Task<string> Comment(CommentSaveDto dto);

        Task<string> Confirm(Guid newId);

        Task<string> Delete(Guid id);

        Task<MemoryStream> ExportExcel(NewsSearchDto dto);
    }
}
