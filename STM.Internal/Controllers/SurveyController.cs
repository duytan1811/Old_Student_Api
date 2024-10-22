namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Surveys;
    using STM.API.Responses.Base;
    using STM.API.Responses.Surveys;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Surveys;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/surveys")]
    public class SurveyController : BaseApiController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(
            ILogger<SurveyController> logger,
            IMapper mapper,
            IAccountService accountService,
            ISurveyService surveyService)
            : base(logger, mapper, accountService)
        {
            this._surveyService = surveyService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<SurveyResponseDto>> Search(BaseSearchRequest<SurveySearchRequestDto> request)
        {
            var response = new BaseTableResponse<SurveyResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new SurveySearchRequestDto();
                }

                var searchDto = this.Mapper.Map<SurveySearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;
                searchDto.CurrentUserId = this.UserLogin.Id;

                var allItems = await this._surveyService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<SurveyResponseDto>>(pagedItems);
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
        public async Task<BaseResponse<SurveyResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<SurveyResponseDto>();

            try
            {
                var result = await this._surveyService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<SurveyResponseDto>(result);
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
        public async Task<BaseResponse<string>> Create(SurveySaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<SurveySaveDto>(request);
                var result = await this._surveyService.Create(dto);

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
        public async Task<BaseResponse<string>> Update(string id, SurveySaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<SurveySaveDto>(request);
                var result = await this._surveyService.Update(dto);

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
                var result = await this._surveyService.Delete(id);
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

        [HttpPost("{id}/survey-result")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> SaveSurveyResult(Guid id, SurveyResultSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                var dto = this.Mapper.Map<SurveyResultSaveDto>(request);
                var result = await this._surveyService.SaveSurveryResult(id, dto);
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
