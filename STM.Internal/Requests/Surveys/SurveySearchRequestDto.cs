namespace STM.API.Requests.Surveys
{
    using STM.Common.Enums;

    public class SurveySearchRequestDto
    {
        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public StatusEnum? Status { get; set; }
    }
}
