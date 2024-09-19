namespace STM.DataTranferObjects.Base
{
    public class BaseSaveDto
    {
        public Guid? Id { get; set; }

        public int? Status { get; set; }

        public bool IsActive { get; set; } = true;

        public string? CreateOrUpdateById { get; set; }
    }
}
