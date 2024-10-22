namespace STM.API.Responses.Surveys
{
    using STM.API.Responses.Base;
    using STM.API.Responses.Questions;

    public class SurveyResponseDto : BaseItemResponse
    {
        public SurveyResponseDto()
        {
            this.QuestionIds = new List<Guid>();
        }

        public string Name { get; set; }

        public int Type { get; set; }

        public DateTime? StartDate { get; set; }

        public string? StartDateFormat => this.StartDate?.ToString("yyyy-MM-dd");

        public DateTime? EndDate { get; set; }

        public string? EndDateFormat => this.EndDate?.ToString("yyyy-MM-dd");

        public List<Guid>? QuestionIds { get; set; }

        public List<QuestionResponseDto>? Questions { get; set; }

        public bool IsExpried => this.EndDate < DateTime.Now;

        public bool IsSurveyed { get; set; }

        public int CountSurveyed { get; set; }
    }
}
