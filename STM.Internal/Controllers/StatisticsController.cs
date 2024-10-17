namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.API.Filters;
    using STM.API.Responses.Base;
    using STM.API.Responses.Statistics;
    using STM.Common.Constants;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/statistics")]
    public class StatisticsController : BaseApiController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(
            ILogger<StatisticsController> logger,
            IMapper mapper,
            IAccountService accountService,
            IStatisticsService statisticsService)
            : base(logger, mapper, accountService)
        {
            this._statisticsService = statisticsService;
        }

        [HttpGet("event-by-month")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<List<EventByMonthResponseDto>>> GetEventByMonth()
        {
            var response = new BaseResponse<List<EventByMonthResponseDto>>();

            try
            {
                var result = await this._statisticsService.GetEventByMonths();

                response.Data = this.Mapper.Map<List<EventByMonthResponseDto>>(result);
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

        [HttpGet("member-by-month")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<List<MemberByMonthResponseDto>>> GetMemberByMonth()
        {
            var response = new BaseResponse<List<MemberByMonthResponseDto>>();

            try
            {
                var result = await this._statisticsService.GetMemberByMonths();

                response.Data = this.Mapper.Map<List<MemberByMonthResponseDto>>(result);
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

        [HttpGet("news-by-month")]
        [TypeFilter(typeof(PermissionFilter), Arguments = new object[] { MenuConstants.Setting, PermissionConstants.View })]
        public async Task<BaseResponse<List<NewsByMonthResponseDto>>> GetNewsByMonth()
        {
            var response = new BaseResponse<List<NewsByMonthResponseDto>>();

            try
            {
                var result = await this._statisticsService.GetNewsByMonths();

                response.Data = this.Mapper.Map<List<NewsByMonthResponseDto>>(result);
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
