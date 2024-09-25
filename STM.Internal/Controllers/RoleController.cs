namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Roles;
    using STM.API.Responses.Base;
    using STM.API.Responses.Roles;
    using STM.API.Responses.Users;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Roles;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/roles")]
    public class RoleController : BaseApiController
    {
        private readonly IRoleService _roleService;

        public RoleController(
            ILogger<RoleController> logger,
            IMapper mapper,
            IAccountService accountService,
            IRoleService roleService)
            : base(logger, mapper, accountService)
        {
            this._roleService = roleService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.View })]
        public async Task<BaseTableResponse<RoleResponse>> Search(BaseSearchRequest<RoleSearchRequest> request)
        {
            var response = new BaseTableResponse<RoleResponse>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new RoleSearchRequest();
                }

                var searchDto = this.Mapper.Map<RoleSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;

                var allItems = await this._roleService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<RoleResponse>>(pagedItems);
                response.Total = allItems.Count();

                var startIndex = request.Start + 1;
                response.Items.ForEach(i => i.Index = startIndex++);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpPost("{roleId}/users")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.Edit })]
        public async Task<BaseTableResponse<UserResponse>> SearchUserByRoleId(string roleId, BaseSearchRequest<RoleSearchRequest> request)
        {
            var response = new BaseTableResponse<UserResponse>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new RoleSearchRequest();
                }

                var searchDto = this.Mapper.Map<RoleSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;

                var allItems = await this._roleService.SearchUsersByRoleId(roleId, searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<UserResponse>>(pagedItems);
                response.Total = allItems.Count();

                var startIndex = request.Start + 1;
                response.Items.ForEach(i => i.Index = startIndex++);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.View })]
        public async Task<BaseResponse<RoleResponse>> FindById(Guid id)
        {
            var response = new BaseResponse<RoleResponse>();

            try
            {
                var result = await this._roleService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<RoleResponse>(result);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpPost]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.Create })]
        public async Task<BaseResponse<ActionStatusEnum>> Create(RoleSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var dto = this.Mapper.Map<RoleSaveDto>(request);
                var result = await this._roleService.Create(dto);

                if (result == ActionStatusEnum.CodeExists)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.Exists;
                    return response;
                }

                response.Message = string.Format(Messages.CreateSuccess, MenuConstants.Role);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.Edit })]
        public async Task<BaseResponse<ActionStatusEnum>> Update(string id, RoleSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<RoleSaveDto>(request);
                var result = await this._roleService.Update(dto);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                if (result == ActionStatusEnum.CodeExists)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.Exists;
                    return response;
                }

                response.Message = string.Format(Messages.UpdateSuccess, MenuConstants.Role);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.Delete })]
        public async Task<BaseResponse<ActionStatusEnum>> Delete(Guid id)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var result = await this._roleService.Delete(id);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Message = string.Format(Messages.DeleteSuccess, MenuConstants.Role);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpPut("{roleId}/users")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.Edit })]
        public async Task<BaseResponse<ActionStatusEnum>> SaveUserByRole(Guid roleId, UserRoleSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                request.RoleId = roleId;
                var saveDto = this.Mapper.Map<UserRoleSaveDto>(request);
                var result = await this._roleService.SaveUsersRole(saveDto);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Message = string.Format(Messages.UpdateSuccess, MenuConstants.Role);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Message = Messages.Exception;
                return response;
            }
        }

        [HttpDelete("{roleId}/users")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Role, PermissionConstants.Edit })]
        public async Task<BaseResponse<ActionStatusEnum>> DeleteUserByRole(Guid roleId, UserRoleSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                request.RoleId = roleId;
                var saveDto = this.Mapper.Map<UserRoleSaveDto>(request);
                var result = await this._roleService.DeleteUsersRole(saveDto);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Message = Messages.DeleteSuccess;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Message = Messages.Exception;
                return response;
            }
        }
    }
}
