namespace STM.DataTranferObjects.Events
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class EventSaveDto : BaseSaveDto
    {
        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public EventTypeEnum Type { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string? Content { get; set; }
    }
}
