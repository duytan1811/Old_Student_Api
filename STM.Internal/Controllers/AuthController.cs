namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Requests.Auth;
    using STM.API.Responses.Auth;
    using STM.API.Responses.Base;
    using STM.API.Responses.Users;
    using STM.Common.Constants;
    using STM.Common.Utilities;
    using STM.Entities.Models;
    using STM.Services.IServices;

    [AllowAnonymous]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : BaseApiController
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(
            ILogger<AuthController> logger,
            IMapper mapper,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IAccountService accountService)
            : base(logger, mapper, accountService)
        {
            this._accountService = accountService;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<BaseResponse<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var response = new BaseResponse<LoginResponse>();
            try
            {
                var user = await this._userManager.FindByNameAsync(loginRequest.Username);
                if (user == null)
                {
                    response.Type = GlobalConstants.Error;
                    response.Key = Messages.LoginUserNotFound;
                    return response;
                }

                var validateLogin = await this.ValidatePassword(loginRequest);
                if (validateLogin.Type == GlobalConstants.Error)
                {
                    return validateLogin;
                }

                // generate token if login success
                var tokenDto = await this._accountService.GenerateToken(loginRequest.Username);

                response.Data = new LoginResponse()
                {
                    Token = tokenDto.Token,
                    Expiration = tokenDto.Expiration.ConvertToTime(),
                };

                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.LoginException;
            }

            return response;
        }

        [HttpGet("user")]
        public BaseResponse<UserResponse> GetUserByToken()
        {
            return new BaseResponse<UserResponse>
            {
                Data = this.Mapper.Map<UserResponse>(this.UserLogin),
            };
        }

        private async Task<BaseResponse<LoginResponse>> ValidatePassword(LoginRequest request)
        {
            var response = new BaseResponse<LoginResponse>();

            var result = await this._signInManager.PasswordSignInAsync(request.Username, request.Password, false, true);
            if (result.IsLockedOut)
            {
                response.Type = GlobalConstants.Error;
                response.Key = Messages.LoginUserLocked;
                return response;
            }

            if (!result.Succeeded)
            {
                response.Type = GlobalConstants.Error;
                response.Key = Messages.LoginIncorrect;
                return response;
            }

            return response;
        }
    }
}
