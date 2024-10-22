﻿namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.SurveyTemplates;
    using STM.API.Responses.Base;
    using STM.API.Responses.SurveyTemplates;
    using STM.Common.Constants;
    using STM.DataTranferObjects.SurveyTemplates;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/survey-templates")]
    public class SurveyTemplateController : BaseApiController
    {
        private readonly ISurveyTemplateService _surveyTemplateService;

        public SurveyTemplateController(
            ILogger<SurveyTemplateController> logger,
            IMapper mapper,
            IAccountService accountService,
            ISurveyTemplateService surveyTemplateService)
            : base(logger, mapper, accountService)
        {
            this._surveyTemplateService = surveyTemplateService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<SurveyTemplateResponseDto>> Search(BaseSearchRequest<SurveyTemplateSearchRequestDto> request)
        {
            var response = new BaseTableResponse<SurveyTemplateResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new SurveyTemplateSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<SurveyTemplateSearchDto>(request.SearchParams);

                var allItems = await this._surveyTemplateService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<SurveyTemplateResponseDto>>(pagedItems);
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
        public async Task<BaseResponse<SurveyTemplateResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<SurveyTemplateResponseDto>();

            try
            {
                var result = await this._surveyTemplateService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<SurveyTemplateResponseDto>(result);
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
        public async Task<BaseResponse<string>> Create(SurveyTemplateSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<SurveyTemplateSaveDto>(request);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(string id, SurveyTemplateSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<SurveyTemplateSaveDto>(request);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._surveyTemplateService.Delete(id);
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
