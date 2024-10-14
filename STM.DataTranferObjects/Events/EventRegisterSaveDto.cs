namespace STM.DataTranferObjects.Events
{
    using STM.DataTranferObjects.Base;

    public class EventRegisterSaveDto : BaseSaveDto
    {
        public Guid? UserId { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
