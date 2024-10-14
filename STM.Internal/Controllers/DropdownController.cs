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
                resposne.Message = ex.Message;
                return resposne;
            }
        }

        [HttpGet("majors")]
        public async Task<BaseResponse<List<SelectListItem>>> GetMajors()
        {
            var resposne = new BaseResponse<List<SelectListItem>>();

            try
            {
                resposne.Data = await this._dropdownService.GetMajors();
                return resposne;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Get dropdown major error: {ex.Message}");
                resposne.Type = GlobalConstants.Error;
                resposne.Message = ex.Message;
                return resposne;
            }
        }

        [HttpGet("roles")]
        public async Task<BaseResponse<List<SelectListItem>>> GetRoles()
        {
            var resposne = new BaseResponse<List<SelectListItem>>();

            try
            {
                resposne.Data = await this._dropdownService.GetRoles();
                return resposne;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Get dropdown role error: {ex.Message}");
                resposne.Type = GlobalConstants.Error;
                resposne.Message = ex.Message;
                return resposne;
            }
        }

        [HttpGet("news-types")]
        public BaseResponse<List<SelectListItem>> GetNewsTypes()
        {
            var resposne = new BaseResponse<List<SelectListItem>>();

            try
            {
                resposne.Data = this._dropdownService.GetNewTypes();
                return resposne;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Get dropdown news types error: {ex.Message}");
                resposne.Type = GlobalConstants.Error;
                resposne.Message = ex.Message;
                return resposne;
            }
        }

        [HttpGet("events")]
        public BaseResponse<List<SelectListItem>> GetEventTypes()
        {
            var resposne = new BaseResponse<List<SelectListItem>>();

            try
            {
                resposne.Data = this._dropdownService.GetEventTypes();
                return resposne;
            }
            catch (Exception ex)
            {
                this.Logger.LogError($"Get dropdown event types error: {ex.Message}");
                resposne.Type = GlobalConstants.Error;
                resposne.Message = ex.Message;
                return resposne;
            }
        }
    }
}
