namespace STM.DataTranferObjects.Events
{
    using STM.DataTranferObjects.Base;

    public class EventRegisterDto : BaseDto
    {
        public Guid? EventId { get; set; }

        public Guid? UserId { get; set; }

        public string? FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
