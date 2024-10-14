namespace STM.API.Requests.Events
{
    public class EventRegisterSaveRequestDto
    {
        public Guid? UserId { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
