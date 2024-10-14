namespace STM.API.Responses.Events
{
    using STM.API.Responses.Base;

    public class EventRegisterResponseDto : BaseItemResponse
    {
        public Guid? EventId { get; set; }

        public Guid? UserId { get; set; }

        public string? FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
