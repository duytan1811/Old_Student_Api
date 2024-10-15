namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Events;
    using STM.API.Responses.Base;
    using STM.API.Responses.Events;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Events;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/events")]
    public class EventController : BaseApiController
    {
        private readonly IEventService _eventService;

        public EventController(
            ILogger<EventController> logger,
            IMapper mapper,
            IAccountService accountService,
            IEventService eventService)
            : base(logger, mapper, accountService)
        {
            this._eventService = eventService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<EventResponseDto>> Search(BaseSearchRequest<EventSearchRequestDto> request)
        {
            var response = new BaseTableResponse<EventResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new EventSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<EventSearchDto>(request.SearchParams);
                searchDto.UserId = this.UserLogin.Id;
                searchDto.Column = request.Sorting.Column;
                searchDto.Direction = request.Sorting.Direction;

                var allItems = await this._eventService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<EventResponseDto>>(pagedItems);
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
        public async Task<BaseResponse<EventResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<EventResponseDto>();

            try
            {
                var result = await this._eventService.FindById(id, this.UserLogin.Id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<EventResponseDto>(result);
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
        public async Task<BaseResponse<string>> Create(EventSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<EventSaveDto>(request);
                var result = await this._eventService.Create(dto);

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
        public async Task<BaseResponse<string>> Update(string id, EventSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<EventSaveDto>(request);
                var result = await this._eventService.Update(dto);

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

        [HttpPost("{id}/user-registers")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<EventRegisterResponseDto>> GetEventRegisters(Guid id, BaseSearchRequest<EventRegisterSearchRequestDto> request)
        {
            var response = new BaseTableResponse<EventRegisterResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new EventRegisterSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<EventRegisterSearchDto>(request.SearchParams);

                var allItems = await this._eventService.GetUserRegisters(id, searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<EventRegisterResponseDto>>(pagedItems);
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

        [HttpPost("{id}/registers")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> EventRegisters(Guid id, EventRegisterSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<EventRegisterSaveDto>(request);
                dto.UserId = this.UserLogin.Id;
                var result = await this._eventService.Register(id, dto);

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
                var result = await this._eventService.Delete(id);
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

        [HttpGet("export-excel")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> ExportTemplate([FromForm] BaseSearchRequest<EventSearchRequestDto> request)
        {
            var response = new BaseResponse<string>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new EventSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<EventSearchDto>(request.SearchParams);
                searchDto.UserId = this.UserLogin.Id;
                searchDto.Column = request.Sorting.Column;
                searchDto.Direction = request.Sorting.Direction;

                var result = await this._eventService.ExportExcel(searchDto);

                byte[] b = result.ToArray();
                response.Data = Convert.ToBase64String(b);
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
