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
        private readonly string _claimType;
        private readonly string _claimValue;

        public PermissionFilter(ILogger<PermissionFilter> logger, IRoleService roleService, string claimType, string claimValue)
        {
            this._logger = logger;
            this._roleService = roleService;
            this._claimType = claimType;
            this._claimValue = claimValue;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                var tokenEncodedString = context.HttpContext.Request.Headers["Authorization"].ToString();
                var token = new JwtSecurityToken(tokenEncodedString.Substring(7));
                var userInfo = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

                if (string.IsNullOrEmpty(userInfo))
                {
                    this._logger.LogError($"Api PermissionFilter missing userInfo in token");
                    context.Result = new StatusCodeResult(403);
                }

                CurrentUserViewModel userInfoViewModel = JsonConvert.DeserializeObject<CurrentUserViewModel>(userInfo);

                var hasPermission = this._roleService.HasPermission(userInfoViewModel.Id, this._claimType, this._claimValue).GetAwaiter().GetResult();

                if (!hasPermission)
                {
                    context.Result = new JsonResult(new BaseResponse<bool>
                    {
                        Type = GlobalConstants.Error,
                        Message = "Bạn chưa có quyền truy cập",
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
