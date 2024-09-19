namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Users;
    using STM.API.Responses.Base;
    using STM.API.Responses.Users;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Users;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly IStringLocalizer<AccountController> _localizer;
        private readonly IUserService _userService;

        public AccountController(
            ILogger<AccountController> logger,
            IMapper mapper,
            IStringLocalizer<AccountController> localizer,
            IAccountService accountService,
            IUserService userService)
            : base(logger, mapper, accountService)
        {
            this._localizer = localizer;
            this._userService = userService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { GlobalConstants.Menu.Major, PermissionConstants.View })]
        public async Task<BaseTableResponse<UserResponse>> Search(BaseSearchRequest<UserSearchRequest> request)
        {
            var response = new BaseTableResponse<UserResponse>();

            try
            {
                var searchDto = this.Mapper.Map<UserSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;

                var allItems = await this._userService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<UserResponse>>(pagedItems);
                response.Total = allItems.Count();

                var startIndex = request.Start + 1;
                response.Items.ForEach(i => i.Index = startIndex++);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
            }

            return response;
        }
    }
}
