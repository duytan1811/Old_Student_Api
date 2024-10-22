namespace STM.API.Requests.Surveys
{
    public class SurveyResultSaveRequestDto
    {
        public SurveyResultSaveRequestDto()
        {
            this.Questions = new List<SurveyResultSaveRequestItemDto>();
        }

        public List<SurveyResultSaveRequestItemDto> Questions { get; set; }
    }

    public class SurveyResultSaveRequestItemDto
    {
        public Guid QuestionId { get; set; }

        public int? Point { get; set; }

        public string? Comment { get; set; }
    }
}
