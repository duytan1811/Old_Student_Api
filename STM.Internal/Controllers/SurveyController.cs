namespace STM.API.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using STM.Services.IServices;

    [ApiController]
    [Route("api/surveys")]
    public class SurveyController : BaseApiController
    {
        private readonly IEventService _eventService;

        public SurveyController(
            ILogger<SurveyController> logger,
            IMapper mapper,
            IAccountService accountService,
            IEventService eventService)
            : base(logger, mapper, accountService)
        {
            this._eventService = eventService;
        }
    }
}
