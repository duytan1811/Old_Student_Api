﻿namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Users;
    using STM.API.Responses.Base;
    using STM.API.Responses.Users;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Users;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/users")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(
            ILogger<UserController> logger,
            IMapper mapper,
            IAccountService accountService,
            IUserService userService)
            : base(logger, mapper, accountService)
        {
            this._userService = userService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.User, PermissionConstants.View })]
        public async Task<BaseTableResponse<UserResponse>> Search(BaseSearchRequest<UserSearchRequest> request)
        {
            var response = new BaseTableResponse<UserResponse>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new UserSearchRequest();
                }

                var searchDto = this.Mapper.Map<UserSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;

                var allItems = await this._userService.Search(searchDto);
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
                return response;
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.User, PermissionConstants.View })]
        public async Task<BaseResponse<UserResponse>> FindById(string id)
        {
            var response = new BaseResponse<UserResponse>();

            try
            {
                var result = await this._userService.FindById(Guid.Parse(id));

                if (result.Id == Guid.Empty)
                {
                    response.Type = GlobalConstants.Error;
                    response.Key = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<UserResponse>(result);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpPost]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.User, PermissionConstants.Create })]
        public async Task<BaseResponse<ActionStatusEnum>> Create(UserSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var dto = this.Mapper.Map<UserSaveDto>(request);
                var result = await this._userService.Create(dto);

                if (result != ActionStatusEnum.Success)
                {
                    response.Type = GlobalConstants.Error;
                    response.Key = Messages.NotFound;
                    return response;
                }

                response.Key = Messages.CreateSuccess;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.User, PermissionConstants.Edit })]
        public async Task<BaseResponse<ActionStatusEnum>> Update(string id, UserSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<UserSaveDto>(request);
                var result = await this._userService.Update(dto);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Key = Messages.NotFound;
                    return response;
                }

                response.Key = Messages.UpdateSuccess;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.User, PermissionConstants.Delete })]
        public async Task<BaseResponse<ActionStatusEnum>> Delete(Guid id)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var result = await this._userService.Delete(id);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Key = Messages.DeleteSuccess;
                    return response;
                }

                response.Key = Messages.DeleteSuccess;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }
    }
}
