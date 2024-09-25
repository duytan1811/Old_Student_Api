namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Tables;
    using STM.API.Responses.Base;
    using STM.API.Responses.Tables;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Majors;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/majors")]
    public class MajorController : BaseApiController
    {
        private readonly IMajorService _majorService;

        public MajorController(
            ILogger<MajorController> logger,
            IMapper mapper,
            IAccountService accountService,
            IMajorService majorService)
            : base(logger, mapper, accountService)
        {
            this._majorService = majorService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<MajorResponseDto>> Search(BaseSearchRequest<MajorSearchRequestDto> request)
        {
            var response = new BaseTableResponse<MajorResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new MajorSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<MajorSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.Order;

                var allItems = await this._majorService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<MajorResponseDto>>(pagedItems);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<MajorResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<MajorResponseDto>();

            try
            {
                var result = await this._majorService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<MajorResponseDto>(result);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Create(MajorSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<MajorSaveDto>(request);
                var result = await this._majorService.Create(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(string id, MajorSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<MajorSaveDto>(request);
                var result = await this._majorService.Update(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._majorService.Delete(id);
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