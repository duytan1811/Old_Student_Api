namespace STM.Services.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Common.Utilities;
    using STM.DataTranferObjects.Roles;
    using STM.DataTranferObjects.Users;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(
            IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<RoleDto>> Search(RoleSearchDto dto)
        {
            var queryRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<Role>().QueryAll();

            if (!string.IsNullOrEmpty(dto.Name))
            {
                var formattedName = dto.Name.Trim().ToLower();
                queryRole = queryRole.Where(i => i.Name.ToLower().Contains(formattedName));
            }

            if (dto.Status.HasValue)
            {
                queryRole = queryRole.Where(i => i.Status == dto.Status);
            }

            var query = queryRole
                .OrderBy(x => x.Name).Select(role => new RoleDto
                {
                    Id = role.Id,
                    Status = role.Status,
                    Name = role.Name,
                    CountUsers = role.UserRoles.Count(i => i.IsActive == true),
                });

            return dto.Column switch
            {
                ColumnNames.Name => dto.Ascending ? query.OrderBy(i => i.Name) : query.OrderByDescending(i => i.Name),
                _ => query,
            };
        }

        public async Task<IQueryable<UserDto>> SearchUsersByRoleId(string roleId, RoleSearchDto dto)
        {
            var queryUserRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<UserRole>().QueryAll();
            var queryUser = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();

            var userIdsByRole = new List<Guid>();
            if (!string.IsNullOrEmpty(roleId))
            {
                queryUserRole = queryUserRole.Where(x => x.RoleId == Guid.Parse(roleId));
                userIdsByRole = queryUserRole.Select(x => x.UserId).ToList();
            }

            if (!string.IsNullOrEmpty(dto.UserName))
            {
                var userNameSearch = dto.UserName.ToLower().Trim();
                queryUser = queryUser.Where(x => x.UserName.Contains(userNameSearch));
            }

            return queryUser.Where(x => userIdsByRole.Contains(x.Id))
                    .Select(x => new UserDto
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        Email = x.Email,
                        CreatedAt = x.CreatedAt,
                        UpdatedAt = x.UpdatedAt,
                    });
        }

        public async Task<RoleDto?> FindById(Guid id)
        {
            var queryRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<Role>().QueryAll();

            var role = queryRole.Include(x => x.UserRoles).FirstOrDefault(i => i.Id == id);
            if (role == null)
            {
                return null;
            }

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Status = role.Status,
                CountUsers = role.UserRoles.Count(),
            };
        }

        public async Task<RoleDto> FindByName(string name)
        {
            var queryRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<Role>().QueryAll();

            var role = queryRole.FirstOrDefault(i => i.Name.Trim().ToLower() == name.Trim().ToLower());

            if (role == null)
            {
                return null;
            }

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
            };
        }

        public async Task<ActionStatusEnum> AddUser(UserRoleSaveDto dto)
        {
            var role = await this._unitOfWork.GetRepositoryAsync<Role>().FindById(dto.RoleId);

            if (role == null)
            {
                return ActionStatusEnum.NotFound;
            }

            var userRolerepository = this._unitOfWork.GetRepositoryAsync<UserRole>();

            var oldUserRoles = (await userRolerepository.QueryCondition(i => i.RoleId == dto.RoleId)).ToList();

            foreach (var userId in dto.UserIds)
            {
                var userRole = oldUserRoles.FirstOrDefault(i => i.UserId == userId);

                if (userRole == null)
                {
                    // tạo mới
                    var newUserRole = new UserRole()
                    {
                        RoleId = dto.RoleId,
                        UserId = userId,
                        IsActive = true,
                    };

                    await userRolerepository.Add(newUserRole);
                }
                else
                {
                    // cập nhật
                    userRole.IsActive = true;
                    await userRolerepository.Update(userRole);
                }
            }

            // lấy danh sách người dùng cập nhật khỏi role.
            var userRoleDeletes = oldUserRoles.Where(i => !dto.UserIds.Contains(i.UserId));

            foreach (var userRoleDelete in userRoleDeletes)
            {
                userRoleDelete.IsActive = false;
                await userRolerepository.Update(userRoleDelete);
            }

            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<bool> HasPermission(Guid userId, string menuKey, string permission)
        {
            var user = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().Single(i => i.Id == userId);

            if (user == null)
            {
                return false;
            }

            if (user.IsAdmin)
            {
                return true;
            }

            var queryRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<Role>().QueryAll();
            var queryUserRole = await this._unitOfWork.GetRepositoryReadOnlyAsync<UserRole>().QueryCondition(i => i.UserId == user.Id && i.IsActive == true);

            var query = from r in queryRole
                        join ur in queryUserRole on r.Id equals ur.RoleId
                        select new
                        {
                            Id = r.Id,
                        };

            return query.Any();
        }

        public async Task<ActionStatusEnum> Create(RoleSaveDto dto)
        {
            var roleRep = this._unitOfWork.GetRepositoryAsync<Role>();

            var roleId = Guid.NewGuid();
            var newRole = new Role
            {
                Id = roleId,
                Name = dto.Name,
                Status = dto.Status.HasValue ? dto.Status : StatusEnum.Active.AsInt(),
            };

            await roleRep.Add(newRole);

            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<ActionStatusEnum> Update(RoleSaveDto dto)
        {
            var roleRep = this._unitOfWork.GetRepositoryAsync<Role>();

            var role = await roleRep.Single(x => x.Id == dto.Id);

            if (role == null)
            {
                return ActionStatusEnum.NotFound;
            }

            role.Name = dto.Name;
            role.Status = dto.Status;

            await roleRep.Update(role);
            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<ActionStatusEnum> Delete(Guid id)
        {
            var roleRep = this._unitOfWork.GetRepositoryAsync<Role>();

            var role = await roleRep.Single(x => x.Id == id);

            if (role == null)
            {
                return ActionStatusEnum.NotFound;
            }

            await roleRep.Delete(role);
            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<ActionStatusEnum> SaveUsersRole(UserRoleSaveDto dto)
        {
            var userRoleRep = this._unitOfWork.GetRepositoryAsync<UserRole>();

            var oldUserRoles = await userRoleRep.QueryCondition(x => x.RoleId == dto.RoleId);
            var oldUserIds = oldUserRoles.Select(x => x.UserId).ToList();

            var userRoles = new List<UserRole>();

            if (dto.UserIds.Any())
            {
                var deleteUserRoles = oldUserRoles.Where(x => !dto.UserIds.Contains(x.UserId)).ToList();
                await userRoleRep.Delete(deleteUserRoles);

                var newUserRoles = dto.UserIds.Where(x => !oldUserIds.Contains(x)).ToList();

                foreach (var userId in newUserRoles)
                {
                    userRoles.Add(new UserRole
                    {
                        RoleId = dto.RoleId,
                        UserId = userId,
                        IsActive = true,
                    });
                }
            }
            else
            {
                await userRoleRep.Delete(oldUserRoles);
            }

            await userRoleRep.Add(userRoles);
            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }

        public async Task<ActionStatusEnum> DeleteUsersRole(UserRoleSaveDto dto)
        {
            var userRoleRep = this._unitOfWork.GetRepositoryAsync<UserRole>();

            var oldUserRoles = await userRoleRep.QueryCondition(x => x.RoleId == dto.RoleId);
            if (dto.UserIds.Any())
            {
                var deleteUserRoles = oldUserRoles.Where(x => dto.UserIds.Contains(x.UserId)).ToList();
                await userRoleRep.Delete(deleteUserRoles);
            }

            await this._unitOfWork.SaveChangesAsync();

            return ActionStatusEnum.Success;
        }
    }
}
