namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Fourms;
    using STM.API.Responses.Base;
    using STM.API.Responses.Fourms;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Fourms;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/forums")]
    public class FourmController : BaseApiController
    {
        private IFourmService _fourmService;

        public FourmController(
             ILogger<FourmController> logger,
             IMapper mapper,
             IAccountService accountService,
             IFourmService fourmService)
            : base(logger, mapper, accountService)
        {
            this._fourmService = fourmService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<FourmResponseDto>> Search(BaseSearchRequest<FourmSearchRequestDto> request)
        {
            var response = new BaseTableResponse<FourmResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new FourmSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<FourmSearchDto>(request.SearchParams);

                var allItems = await this._fourmService.Search(searchDto, this.UserLogin.Id);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<FourmResponseDto>>(pagedItems);
                response.Total = allItems.Count();

                var startIndex = request.Start + 1;
                response.Items.ForEach(i => i.Index = startIndex++);
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
