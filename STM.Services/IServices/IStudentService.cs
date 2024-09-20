namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Students;

    public interface IStudentService
    {
        Task<IQueryable<StudentDto>> Search(StudentSearchDto dto);

        Task<StudentDto?> FindById(Guid id);

        Task<string> Create(StudentSaveDto dto);

        Task<string> Update(StudentSaveDto dto);

        Task<string> Delete(Guid id);
    }
}
