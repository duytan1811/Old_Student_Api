namespace STM.API.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using STM.Services.IServices;
    using STM.ViewModels.Accounts;

    [Authorize]
    public class BaseApiController : Controller
    {
        public BaseApiController(
            ILogger<BaseApiController> logger,
            IMapper mapper,
            IAccountService accountService)
        {
            this.Logger = logger;
            this.Mapper = mapper;
            this.AccountService = accountService;
        }

        public CurrentUserViewModel? UserLogin
        {
            get
            {
                var tokenEncodedString = this.HttpContext.Request.Headers["Authorization"].ToString();
                CurrentUserViewModel userInfoViewModel = null;
                if (!string.IsNullOrEmpty(tokenEncodedString))
                {
                    if (tokenEncodedString.Substring(7) != "undefined")
                    {
                        var token = new JwtSecurityToken(tokenEncodedString.Substring(7));
                        try
                        {
                            var userInfo = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
                            if (string.IsNullOrEmpty(userInfo))
                            {
                                return null;
                            }

                            userInfoViewModel = JsonConvert.DeserializeObject<CurrentUserViewModel>(userInfo);
                        }
                        catch (Exception ex)
                        {
                            this.Logger.LogError($"Error :{ex.Message}");
                            return null;
                        }
                    }
                }

                return userInfoViewModel;
            }
        }

        protected ILogger<BaseApiController> Logger { get; }

        protected IMapper Mapper { get; }

        protected IAccountService AccountService { get; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = this.UserLogin;

            this.AccountService.SetCurrentUser(currentUser?.Id);

            base.OnActionExecuting(filterContext);
        }
    }
}
