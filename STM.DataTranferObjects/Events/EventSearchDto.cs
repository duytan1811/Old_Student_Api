namespace STM.DataTranferObjects.Events
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class EventSearchDto : BaseSearchDto
    {
        public EventTypeEnum? Type { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? UserId { get; set; }
    }
}
