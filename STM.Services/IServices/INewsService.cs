namespace STM.Services.IServices
{
    using STM.DataTranferObjects.News;

    public interface INewsService
    {
        Task<IQueryable<NewsDto>> Search(NewsSearchDto dto);

        Task<NewsDto?> FindById(Guid id);

        Task<string> Create(NewsSaveDto dto);

        Task<string> Update(NewsSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
