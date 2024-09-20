namespace STM.API.Requests.Tables
{
    using STM.Common.Enums;

    public class MajorSearchRequestDto
    {
        public string? Name { get; set; }

        public StatusEnum? Status { get; set; }
    }
}
