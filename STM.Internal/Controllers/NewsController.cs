namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.News;
    using STM.API.Responses.Base;
    using STM.API.Responses.News;
    using STM.Common.Constants;
    using STM.DataTranferObjects.News;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/news")]
    public class NewsController : BaseApiController
    {
        private readonly INewsService _newsService;

        public NewsController(
            ILogger<NewsController> logger,
            IMapper mapper,
            IAccountService accountService,
            INewsService newsService)
            : base(logger, mapper, accountService)
        {
            this._newsService = newsService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<NewsResponseDto>> Search(BaseSearchRequest<NewsSearchRequestDto> request)
        {
            var response = new BaseTableResponse<NewsResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new NewsSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<NewsSearchDto>(request.SearchParams);

                var allItems = await this._newsService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<NewsResponseDto>>(pagedItems);
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
        public async Task<BaseResponse<NewsResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<NewsResponseDto>();

            try
            {
                var result = await this._newsService.FindById(id, this.UserLogin.Id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<NewsResponseDto>(result);
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
        public async Task<BaseResponse<string>> Create(NewsSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<NewsSaveDto>(request);
                dto.CurrentUserId = this.UserLogin.Id;
                var result = await this._newsService.Create(dto);

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
        public async Task<BaseResponse<string>> Update(string id, NewsSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<NewsSaveDto>(request);
                var result = await this._newsService.Update(dto);

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

        [HttpGet("{id}/like")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Like(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var currentUserId = this.UserLogin.Id;
                var result = await this._newsService.Like(id, currentUserId);

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

        [HttpPost("{id}/comments/search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseTableResponse<CommentResponseDto>> GetComments(BaseSearchRequest<CommentSearchRequestDto> request)
        {
            var response = new BaseTableResponse<CommentResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new CommentSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<CommentSearchDto>(request.SearchParams);

                var allItems = await this._newsService.GetComments(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<CommentResponseDto>>(pagedItems);
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

        [HttpPost("{id}/comments")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Comment(CommentSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                var dto = this.Mapper.Map<CommentSaveDto>(request);

                var currentUserId = this.UserLogin.Id;
                dto.UserId = currentUserId;
                var result = await this._newsService.Comment(dto);

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

        [HttpGet("{id}/confirm")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Confirm(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._newsService.Confirm(id);

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
                var result = await this._newsService.Delete(id);
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
