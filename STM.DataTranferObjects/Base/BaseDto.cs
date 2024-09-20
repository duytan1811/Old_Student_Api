namespace STM.DataTranferObjects.Base
{
    using STM.Common.Enums;

    public class BaseDto
    {
        public Guid Id { get; set; }

        public StatusEnum? Status { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Guid? CreatedById { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedById { get; set; }
    }
}
