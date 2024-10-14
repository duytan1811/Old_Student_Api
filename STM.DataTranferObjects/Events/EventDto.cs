namespace STM.DataTranferObjects.Events
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class EventDto : BaseDto
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public EventTypeEnum Type { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string? Content { get; set; }

        public int CountEventRegister { get; set; }

        public bool IsRegister { get; set; }
    }
}
