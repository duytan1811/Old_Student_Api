namespace STM.API.Filters
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using STM.API.Responses.Base;
    using STM.Common.Constants;
    using STM.Services.IServices;
    using STM.ViewModels.Accounts;

    public class PermissionFilter : IActionFilter
    {
        private readonly ILogger<PermissionFilter> _logger;
        private readonly IRoleService _roleService;
        private readonly string _menuKey;
        private readonly string _permission;

        public PermissionFilter(ILogger<PermissionFilter> logger, IRoleService roleService, string menuKey, string permission)
        {
            this._logger = logger;
            this._roleService = roleService;
            this._menuKey = menuKey;
            this._permission = permission;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var tokenEncodedString = context.HttpContext.Request.Headers["Authorization"].ToString();
                var token = new JwtSecurityToken(tokenEncodedString.Substring(7)); // trim 'Bearer ' from the start since its just a prefix for the token string
                var userInfo = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

                if (string.IsNullOrEmpty(userInfo))
                {
                    this._logger.LogError($"Api PermissionFilter missing userInfo in token");
                    context.Result = new StatusCodeResult(403);
                }

                CurrentUserViewModel userInfoViewModel = JsonConvert.DeserializeObject<CurrentUserViewModel>(userInfo);

                var hasPermission = this._roleService.HasPermission(userInfoViewModel.Id, this._menuKey, this._permission).GetAwaiter().GetResult();

                if (!hasPermission)
                {
                    context.Result = new JsonResult(new BaseResponse<bool>
                    {
                        Type = GlobalConstants.Error,
                        Message = "AccessDenied",
                    });
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Api PermissionFilter error: {ex}");
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
