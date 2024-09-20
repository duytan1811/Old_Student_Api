namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Requests.Base;
    using STM.API.Requests.Students;
    using STM.API.Responses.Base;
    using STM.API.Responses.Students;
    using STM.Common.Constants;
    using STM.DataTranferObjects.Students;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/students")]
    public class StudentController : BaseApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(
            ILogger<StudentController> logger,
            IMapper mapper,
            IAccountService accountService,
            IStudentService studentService)
            : base(logger, mapper, accountService)
        {
            this._studentService = studentService;
        }

        [HttpPost("search")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.View })]
        public async Task<BaseTableResponse<StudentResponseDto>> Search(BaseSearchRequest<StudentSearchRequestDto> request)
        {
            var response = new BaseTableResponse<StudentResponseDto>();

            try
            {
                if (request.SearchParams == null)
                {
                    request.SearchParams = new StudentSearchRequestDto();
                }

                var searchDto = this.Mapper.Map<StudentSearchDto>(request.SearchParams);
                searchDto.Column = ColumnNames.Order;

                var allItems = await this._studentService.Search(searchDto);
                var pagedItems = allItems.Skip(request.Start).Take(request.Length).ToList();
                response.Items = this.Mapper.Map<List<StudentResponseDto>>(pagedItems);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<StudentResponseDto>> FindById(Guid id)
        {
            var response = new BaseResponse<StudentResponseDto>();

            try
            {
                var result = await this._studentService.FindById(id);

                if (result == null)
                {
                    response.Message = Messages.NotFound;
                    return response;
                }

                response.Data = this.Mapper.Map<StudentResponseDto>(result);
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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Create })]
        public async Task<BaseResponse<string>> Create(StudentSaveRequestDto request)
        {
            var response = new BaseResponse<string>();
            try
            {
                var dto = this.Mapper.Map<StudentSaveDto>(request);
                var result = await this._studentService.Create(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Edit })]
        public async Task<BaseResponse<string>> Update(string id, StudentSaveRequestDto request)
        {
            var response = new BaseResponse<string>();

            try
            {
                request.Id = id;
                var dto = this.Mapper.Map<StudentSaveDto>(request);
                var result = await this._studentService.Update(dto);

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
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Keys.Setting, PermissionConstants.Delete })]
        public async Task<BaseResponse<string>> Delete(Guid id)
        {
            var response = new BaseResponse<string>();

            try
            {
                var result = await this._studentService.Delete(id);
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
