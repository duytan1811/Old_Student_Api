namespace STM.API.Responses.Events
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class EventResponseDto : BaseItemResponse
    {
        public DateTime? StartDate { get; set; }

        public DateTime? StartDateFormat => this.StartDate;

        public DateTime? EndDate { get; set; }

        public DateTime? EndDateFormat => this.EndDate;

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

        public StatusEnum? Status
        {
            get
            {
                if (this.IsExpired)
                {
                    return StatusEnum.ExpiredDate;
                }
                else if (this.IsComming)
                {
                    return StatusEnum.InComming;
                }
                else if (this.IsProgress)
                {
                    return StatusEnum.InProgress;
                }

                return this.Status;
            }
        }

        public string? StatusName
        {
            get
            {
                if (this.IsExpired)
                {
                    return this.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue(StatusEnum.ExpiredDate) : null;
                }
                else if (this.IsComming)
                {
                    return this.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue(StatusEnum.InComming) : null;
                }
                else if (this.IsProgress)
                {
                    return this.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue(StatusEnum.InProgress) : null;
                }

                return this.StatusName;
            }
        }
    }
}
