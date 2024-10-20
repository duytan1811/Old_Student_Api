namespace STM.Services.IServices
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Users;

    public interface IUserService
    {
        Task<IQueryable<UserDto>> Search(UserSearchDto dto);

        Task<UserDto> FindById(Guid id);

        Task<ActionStatusEnum> Create(UserSaveDto dto);

        Task<ActionStatusEnum> Update(UserSaveDto dto);

        Task<ActionStatusEnum> ResetPassword(string email);

        Task<ActionStatusEnum> Delete(Guid id);

        Task<ActionStatusEnum> ChangePassword(Guid id, ChangePasswordDto dto);

        Task<MemoryStream> ExportExcel(UserSearchDto dto);
    }
}
