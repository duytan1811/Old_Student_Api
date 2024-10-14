namespace STM.API.Requests.Events
{
    using STM.Common.Enums;

    public class EventSearchRequestDto
    {
        public EventTypeEnum? Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? Status { get; set; }
    }
}
