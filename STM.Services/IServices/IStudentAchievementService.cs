namespace STM.Services.IServices
{
    using STM.DataTranferObjects.StudentAchievements;

    public interface IStudentAchievementService
    {
        Task<IQueryable<StudentAchievementDto>> Search(StudentAchievementSearchDto dto);

        Task<StudentAchievementDto?> FindById(Guid id);

        Task<string> Create(StudentAchievementSaveDto dto);

        Task<string> Update(StudentAchievementSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
