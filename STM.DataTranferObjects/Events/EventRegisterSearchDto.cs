namespace STM.DataTranferObjects.Events
{
    using STM.DataTranferObjects.Base;

    public class EventRegisterSearchDto : BaseSearchDto
    {
        public Guid? UserId { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
