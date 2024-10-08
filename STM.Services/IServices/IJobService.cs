namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Jobs;

    public interface IJobService
    {
        Task<IQueryable<JobDto>> Search(JobSearchDto dto);

        Task<JobDto?> FindById(Guid id);

        Task<string> Create(JobSaveDto dto);

        Task<string> Update(JobSaveDto dto);

        Task<string> Delete(Guid id);

        Task<string> ApplyJob(Guid id, ApplyJobSaveDto dto);
    }
}
