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
        private readonly IMajorService _tableService;

        public MajorController(
            ILogger<MajorController> logger,
            IMapper mapper,
            IAccountService accountService,
            IMajorService tableService)
            : base(logger, mapper, accountService)
        {
            this._tableService = tableService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.View })]
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

                var allItems = await this._tableService.Search(searchDto);
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
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<MajorResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<MajorResponseDto>();

            try
            {
                var result = await this._tableService.FindById(id);

                if (result == null)
                {
                    response.Key = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<MajorResponseDto>(result);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpPost]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Create(MajorSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<MajorSaveDto>(request);
                var result = await this._tableService.Create(dto);

                response.Key = result;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpPut("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(string id, MajorSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<MajorSaveDto>(request);
                var result = await this._tableService.Update(dto);

                response.Key = result;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpDelete("{id}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._tableService.Delete(id);
                response.Key = result;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpGet("export-template")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Create })]
        public BaseResponse<string> ExportTemplate()
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = this._tableService.ExportTemplate();

                byte[] b = result.ToArray();
                response.Data = Convert.ToBase64String(b);
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }

        [HttpPost("import")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Import([FromForm] MajorImportRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                var dto = this.Mapper.Map<MajorImportDto>(request);
                var result = await this._tableService.Import(dto);
                response.Key = result;
                return response;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex, ex.Message);
                response.Type = GlobalConstants.Error;
                response.Key = Messages.Exception;
                return response;
            }
        }
    }
}