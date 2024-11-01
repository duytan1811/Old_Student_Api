namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Contributes;
    using STM.API.Responses.Base;
    using STM.API.Responses.Contributes;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Contributes;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/contributes")]
    public class ContributeController : BaseApiController
    {
        private readonly IContributeService _contributeService;

        public ContributeController(
            ILogger<ContributeController> logger,
            IMapper mapper,
            IAccountService accountService,
            IContributeService contributeService)
            : base(logger, mapper, accountService)
        {
            this._contributeService = contributeService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Contribute), PermissionConstants.View })]
        public async Task<BaseTableResponse<ContributeResponseDto>> Search(BaseSearchRequest<ContributeSearchRequestDto> request)
        {
            var response = new BaseTableResponse<ContributeResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new ContributeSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<ContributeSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;

                var allItems = await this._contributeService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<ContributeResponseDto>>(pagedItems);
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

        [HttpGet("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Contribute), PermissionConstants.View })]
        public async Task<BaseResponse<ContributeResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<ContributeResponseDto>();

            try
            {
                var result = await this._contributeService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<ContributeResponseDto>(result);
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

        [HttpPost]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Contribute), PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Create(ContributeSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<ContributeSaveDto>(request);
                var result = await this._contributeService.Create(dto);

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

        [HttpPut("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Contribute), PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(string id, ContributeSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<ContributeSaveDto>(request);
                var result = await this._contributeService.Update(dto);

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

        [HttpDelete("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Contribute), PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._contributeService.Delete(id);
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
