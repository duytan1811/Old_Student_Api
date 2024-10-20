namespace STM.API.Controllers
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.User, PermissionConstants.View })]
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.User, PermissionConstants.View })]
        public async Task<BaseResponse<UserResponse>> FindById(string id)
        {
            var response = new BaseResponse<UserResponse>();

            try
            {
                var result = await this._userService.FindById(Guid.Parse(id));

                if (result.Id == Guid.Empty)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<UserResponse>(result);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.User, PermissionConstants.Create })]
        public async Task<BaseResponse<ActionStatusEnum>> Create(UserSaveRequest request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var dto = this.Mapper.Map<UserSaveDto>(request);
                var result = await this._userService.Create(dto);

                if (result == ActionStatusEnum.UserNameExists)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = string.Format(Messages.Exists, "Tài khoản");
                    return response;
                }

                if (result == ActionStatusEnum.EmailExists)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = string.Format(Messages.Exists, "Email");
                    return response;
                }

                response.Message = string.Format(Messages.CreateSuccess, "Tài khoản");
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.User, PermissionConstants.Edit })]
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
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Message = string.Format(Messages.UpdateSuccess, "Tài khoản");
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.User, PermissionConstants.Delete })]
        public async Task<BaseResponse<ActionStatusEnum>> Delete(Guid id)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var result = await this._userService.Delete(id);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Message = string.Format(Messages.DeleteSuccess, "Tài khoản");
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

        [HttpPost("{id}/change-password")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.User, PermissionConstants.Delete })]
        public async Task<BaseResponse<ActionStatusEnum>> ChangePassword(Guid id, ChangePasswordRequestDto request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var dto = this.Mapper.Map<ChangePasswordDto>(request);
                var result = await this._userService.ChangePassword(id, dto);

                if (result == ActionStatusEnum.NotFound)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = Messages.NotFound;
                    return response;
                }

                if (result == ActionStatusEnum.PasswordIncorrect)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = "Mật khẩu cũ không chính xác";
                    return response;
                }

                if (result == ActionStatusEnum.PasswordLess)
                {
                    response.Type = GlobalConstants.Error;
                    response.Message = "Mật khẩu phải bao gồm các ký tự thường, in hoa, số và ký tự đặc biệt";
                    return response;
                }

                response.Message = Messages.ChangePassword;
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

        [HttpGet("export-excel")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> ExportExcel([FromForm] BaseSearchRequest<UserSearchRequest> request)
        {
            var response = new BaseResponse<string>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new UserSearchRequest();
                }

                var searchDto = this.Mapper.Map<UserSearchDto>(request.SearchParams);
                searchDto.Direction = request.Sorting.Direction;

                var result = await this._userService.ExportExcel(searchDto);

                byte[] b = result.ToArray();
                response.Data = Convert.ToBase64String(b);
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
    }
}
