namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Majors;

    public interface IMajorService
    {
        Task<IQueryable<MajorDto>> Search(MajorSearchDto dto);

        Task<MajorDto?> FindById(Guid id);

        Task<string> Create(MajorSaveDto dto);

        Task<string> Update(MajorSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
