namespace STM.DataTranferObjects.Base
{
    using STM.Common.Enums;

    public class BaseSaveDto
    {
        public Guid? Id { get; set; }

        public StatusEnum? Status { get; set; }

        public bool IsActive { get; set; } = true;

        public string? CreateOrUpdateById { get; set; }
    }
}
