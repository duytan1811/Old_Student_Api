namespace STM.API.Responses.Events
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class EventResponseDto : BaseItemResponse
    {
        public DateTime? StartDate { get; set; }

        public string? StartDateFormat => this.StartDate?.ToString("yyyy-MM-dd");

        public DateTime? EndDate { get; set; }

        public string? EndDateFormat => this.EndDate?.ToString("yyyy-MM-dd");

        public EventTypeEnum Type { get; set; }

        public string TypeName => EnumHelper<EventTypeEnum>.GetDisplayValue(this.Type);

        public string Title { get; set; }

        public string Address { get; set; }

        public string? Content { get; set; }

        public bool IsRegister { get; set; }

        public int CountEventRegister { get; set; }

        public bool IsExpired => this.EndDate < DateTime.Now;

        public bool IsComming => this.StartDate > DateTime.Now;

        public bool IsProgress => this.StartDate < DateTime.Now && DateTime.Now < this.EndDate;
    }
}
