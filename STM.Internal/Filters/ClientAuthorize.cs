namespace STM.API.Filters
{
    using System;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.Logging;
    using STM.API.Responses.Base;
    using STM.Common.Constants;
    using STM.Services.IServices;

    public class ClientAuthorize : IAuthorizationFilter
    {
        private readonly ILogger<ClientAuthorize> _logger;
        private readonly IClientService _clientService;
        private readonly string _scope;

        public ClientAuthorize(ILogger<ClientAuthorize> logger, IClientService clientService, string scope)
        {
            this._logger = logger;
            this._clientService = clientService;
            this._scope = scope;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string clientId = context.HttpContext.Request.Headers["clientId"];
                string clientSecret = context.HttpContext.Request.Headers["clientSecret"];

                if (string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
                {
                    context.Result = new JsonResult(new BaseResponse<bool>
                    {
                        Type = GlobalConstants.Error,
                        Message = "Unauthorized",
                    });

                    return;
                }

                // validate ClientId and ClientSecret
                var valid = this._clientService.IsAuthorize(clientId, clientSecret, this._scope).GetAwaiter().GetResult();

                if (!valid)
                {
                    context.Result = new JsonResult(new BaseResponse<bool>
                    {
                        Type = GlobalConstants.Error,
                        Message = StatusCodes.Status401Unauthorized.ToString(),
                    });

                    return;
                }
            }
            catch (Exception ex)
            {
                this._logger.LogError($"ClientAuthorize error: {ex}");
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
