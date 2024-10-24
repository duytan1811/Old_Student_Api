namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Contributes;

    public interface IContributeService
    {
        Task<IQueryable<ContributeDto>> Search(ContributeSearchDto dto);

        Task<ContributeDto?> FindById(Guid id);

        Task<string> Create(ContributeSaveDto dto);

        Task<string> Update(ContributeSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
