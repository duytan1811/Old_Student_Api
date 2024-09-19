namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using STM.API.Responses.Base;
    using STM.Common.Constants;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/dropdowns")]
    public class DropdownController : BaseApiController
    {
        private readonly IDropdownService _dropdownService;

        public DropdownController(
            ILogger<DropdownController> logger,
            IMapper mapper,
            IAccountService accountService,
            IDropdownService dropdownService)
            : base(logger, mapper, accountService)
        {
            this._dropdownService = dropdownService;
        }

        [HttpGet("users")]
        public async Task<BaseResponse<List<SelectListItem>>> GetUsers()
        {
            var resposne = new BaseResponse<List<SelectListItem>>();

            try
            {
                resposne.Data = await this._dropdownService.GetUsers();
                return resposne;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Get dropdown user error: {ex.Message}");
                resposne.Type = GlobalConstants.Error;
                resposne.Key = ex.Message;
                return resposne;
            }
        }
    }
}
