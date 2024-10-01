namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Fourms;

    public interface IFourmService
    {
        Task<IQueryable<FourmDto>> Search(FourmSearchDto dto, Guid userId);
    }
}
