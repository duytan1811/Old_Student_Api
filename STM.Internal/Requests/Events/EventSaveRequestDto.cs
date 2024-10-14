namespace STM.API.Requests.Events
{
    using STM.API.Requests.Base;
    using STM.Common.Enums;

    public class EventSaveRequestDto : BaseSaveRequest
    {
        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public EventTypeEnum Type { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string? Content { get; set; }
    }
}
