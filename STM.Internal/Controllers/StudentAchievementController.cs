namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.StudentAchievements;
    using STM.API.Responses.Base;
    using STM.API.Responses.StudentAchievements;
    using STM.Common.Constants;
    using STM.DataTranferObjects.StudentAchievements;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/student-achievements")]
    public class StudentAchievementController : BaseApiController
    {
        private readonly IStudentAchievementService _studentAchievementService;

        public StudentAchievementController(
            ILogger<StudentAchievementController> logger,
            IMapper mapper,
            IAccountService accountService,
            IStudentAchievementService studentAchievementService)
            : base(logger, mapper, accountService)
        {
            this._studentAchievementService = studentAchievementService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<StudentAchievementResponseDto>> Search(BaseSearchRequest<StudentAchievementSearchRequestDto> request)
        {
            var response = new BaseTableResponse<StudentAchievementResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new StudentAchievementSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<StudentAchievementSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.CreatedAt;
                searchDto.Direction = "desc";

                var allItems = await this._studentAchievementService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<StudentAchievementResponseDto>>(pagedItems);
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
        public async Task<BaseResponse<StudentAchievementResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<StudentAchievementResponseDto>();

            try
            {
                var result = await this._studentAchievementService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<StudentAchievementResponseDto>(result);
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
        public async Task<BaseResponse<string>> Create(StudentAchievementSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<StudentAchievementSaveDto>(request);
                var result = await this._studentAchievementService.Create(dto);

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
        public async Task<BaseResponse<string>> Update(string id, StudentAchievementSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<StudentAchievementSaveDto>(request);
                var result = await this._studentAchievementService.Update(dto);

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
                var result = await this._studentAchievementService.Delete(id);
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
