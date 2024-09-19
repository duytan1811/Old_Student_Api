namespace STM.Services.IServices
{
    using System.Linq;
    using System.Threading.Tasks;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Roles;
    using STM.DataTranferObjects.Users;

    public interface IRoleService
    {
        Task<IQueryable<RoleDto>> Search(RoleSearchDto dto);

        Task<RoleDto> FindById(Guid id);

        Task<RoleDto> FindByName(string name);

        Task<ActionStatusEnum> Create(RoleSaveDto dto);

        Task<ActionStatusEnum> Update(RoleSaveDto dto);

        Task<ActionStatusEnum> Delete(Guid id);

        Task<IQueryable<UserDto>> SearchUsersByRoleId(string roleId, RoleSearchDto dto);

        Task<ActionStatusEnum> SaveUsersRole(UserRoleSaveDto dto);

        Task<ActionStatusEnum> DeleteUsersRole(UserRoleSaveDto dto);

        Task<bool> HasPermission(Guid userId, string menuKey, string permission);
    }
}
