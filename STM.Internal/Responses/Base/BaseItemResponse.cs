namespace STM.API.Responses.Base
{
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class BaseItemResponse
    {
        public int Index { get; set; }

        public Guid Id { get; set; }

        public StatusEnum? Status { get; set; }

        public string? StatusName => this.Status.HasValue ? EnumHelper<StatusEnum>.GetDisplayValue((int)this.Status) : null;

        public DateTime? CreatedAt { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}
