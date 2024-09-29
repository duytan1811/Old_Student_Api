namespace STM.API.Requests.Majors
{
    using STM.Common.Enums;

    public class MajorSearchRequestDto
    {
        public string? Name { get; set; }

        public StatusEnum? Status { get; set; }
    }
}
