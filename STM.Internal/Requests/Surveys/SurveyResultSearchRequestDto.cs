namespace STM.API.Requests.Surveys
{
    public class SurveyResultSearchRequestDto
    {
        public Guid SurveyId { get; set; }

        public string? FullName { get; set; }

        public DateTime? Date { get; set; }
    }
}
