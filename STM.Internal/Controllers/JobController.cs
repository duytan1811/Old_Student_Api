namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Jobs;
    using STM.API.Responses.Base;
    using STM.API.Responses.Jobs;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Jobs;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/jobs")]
    public class JobController : BaseApiController
    {
        private readonly IJobService _jobService;

        public JobController(
            ILogger<JobController> logger,
            IMapper mapper,
            IAccountService accountService,
            IJobService jobService)
            : base(logger, mapper, accountService)
        {
            this._jobService = jobService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.View })]
        public async Task<BaseTableResponse<JobResponseDto>> Search(BaseSearchRequest<JobSearchRequestDto> request)
        {
            var response = new BaseTableResponse<JobResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new JobSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<JobSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;
                searchDto.CurrentUserId = this.UserLogin.Id;

                var allItems = await this._jobService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<JobResponseDto>>(pagedItems);
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

        [HttpPost("{id}/user-applies")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.View })]
        public async Task<BaseTableResponse<UserApplyResponseDto>> GetUserApplies(Guid id, BaseSearchRequest<UserApplySearchRequestDto> request)
        {
            var response = new BaseTableResponse<UserApplyResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new UserApplySearchRequestDto();
                }

                var searchDto = this.Mapper.Map<UserApplySearchDto>(request.SearchParams);

                var allItems = await this._jobService.GetUserApplies(id, searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<UserApplyResponseDto>>(pagedItems);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.View })]
        public async Task<BaseResponse<JobResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<JobResponseDto>();

            try
            {
                var result = await this._jobService.FindById(id, this.UserLogin.Id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<JobResponseDto>(result);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Create(JobSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<JobSaveDto>(request);
                var result = await this._jobService.Create(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(Guid id, JobSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                var dto = this.Mapper.Map<JobSaveDto>(request);
                dto.Id = id;
                var result = await this._jobService.Update(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._jobService.Delete(id);
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

        [HttpPost("{id}/apply-job")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { nameof(MenuConstants.Job), PermissionConstants.Create })]
        public async Task<BaseResponse<string>> ApplyJob(Guid id, ApplyJobSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                var data = this.Mapper.Map<ApplyJobSaveDto>(request);
                data.UserId = this.UserLogin.Id;

                var result = await this._jobService.ApplyJob(id, data);
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
