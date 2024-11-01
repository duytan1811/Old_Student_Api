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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.View })]
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

        [HttpPost("{surveyId}/survey-results")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.View })]
        public async Task<BaseTableResponse<SurveyResultResponseDto>> SearchSurveyResults(Guid surveyId, BaseSearchRequest<SurveyResultSearchRequestDto> request)
        {
            var response = new BaseTableResponse<SurveyResultResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new SurveyResultSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<SurveyResultSearchDto>(request.SearchParams);
                searchDto.SurveyId = surveyId;
                searchDto.Column = ColumnNames.CreatedAt;

                var allItems = await this._surveyService.SearchServeyResult(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<SurveyResultResponseDto>>(pagedItems);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.View })]
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

        [HttpGet("{surveyId}/survey-results/{userId}")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.View })]
        public async Task<BaseResponse<SurveyResultDetailResponseDto>> GetSurveyDetail(Guid surveyId, Guid userId)
        {
            var response = new BaseResponse<SurveyResultDetailResponseDto>();

            try
            {
                var result = await this._surveyService.GetSurveyDetail(surveyId, userId);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<SurveyResultDetailResponseDto>(result);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.Create })]
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.Edit })]
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._surveyService.Delete(id);
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

        [HttpPost("{id}/survey-result")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Survey), PermissionConstants.Edit })]
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
