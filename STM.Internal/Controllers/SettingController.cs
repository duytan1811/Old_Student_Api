namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Settings;
    using STM.API.Responses.Base;
    using STM.API.Responses.Settings;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.DataTranferObjects.Settings;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/settings")]
    public class SettingController : BaseApiController
    {
        private readonly ISettingService _settingService;

        public SettingController(
            ILogger<SettingController> logger,
            IMapper mapper,
            IAccountService accountService,
            ISettingService settingService)
            : base(logger, mapper, accountService)
        {
            this._settingService = settingService;
        }

        [HttpGet("keys/{key}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<SettingResponse>> GetSetingByKey(string key)
        {
            var response = new BaseResponse<SettingResponse>();

            try
            {
                var setting = await this._settingService.GetSettingByKey(key);
                response.Data = this.Mapper.Map<SettingResponse>(setting);

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

        [HttpGet("types/{type}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<List<SettingResponse>>> GetSetingsByType(string type)
        {
            var response = new BaseResponse<List<SettingResponse>>();

            try
            {
                var setting = await this._settingService.GetSettingsByType(type);
                response.Data = this.Mapper.Map<List<SettingResponse>>(setting);

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

        [HttpPut("update")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<ActionStatusEnum>> Update(List<SettingSaveRequest> request)
        {
            var response = new BaseResponse<ActionStatusEnum>();

            try
            {
                var dto = this.Mapper.Map<List<SettingSaveDto>>(request);
                var result = await this._settingService.Update(dto);

                response.Message = result;
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
