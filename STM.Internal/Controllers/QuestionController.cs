namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Questions;
    using STM.API.Responses.Base;
    using STM.API.Responses.Questions;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Questions;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/questions")]
    public class QuestionController : BaseApiController
    {
        private readonly IQuestionService _surveyTemplateService;

        public QuestionController(
            ILogger<QuestionController> logger,
            IMapper mapper,
            IAccountService accountService,
            IQuestionService surveyTemplateService)
            : base(logger, mapper, accountService)
        {
            this._surveyTemplateService = surveyTemplateService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Question), PermissionConstants.View })]
        public async Task<BaseTableResponse<QuestionResponseDto>> Search(BaseSearchRequest<QuestionSearchRequestDto> request)
        {
            var response = new BaseTableResponse<QuestionResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new QuestionSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<QuestionSearchDto>(request.SearchParams);

                var allItems = await this._surveyTemplateService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<QuestionResponseDto>>(pagedItems);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Question), PermissionConstants.View })]
        public async Task<BaseResponse<QuestionResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<QuestionResponseDto>();

            try
            {
                var result = await this._surveyTemplateService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<QuestionResponseDto>(result);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Question), PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Create(QuestionSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<QuestionSaveDto>(request);
                var result = await this._surveyTemplateService.Create(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Question), PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(string id, QuestionSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<QuestionSaveDto>(request);
                var result = await this._surveyTemplateService.Update(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Question), PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._surveyTemplateService.Delete(id);
                if (result.StartsWith("Không thể"))
                {
                    response.Type = GlobalConstants.Error;
                }

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
