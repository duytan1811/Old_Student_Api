namespace STM.API.Responses.Surveys
{
    public class SurveyResultDetailResponseDto
    {
        public SurveyResultDetailResponseDto()
        {
            this.Items = new List<SurveyResultDetailResponseItemDto>();
        }

        public string CreatedByName { get; set; }

        public List<SurveyResultDetailResponseItemDto> Items { get; set; }
    }

    public class SurveyResultDetailResponseItemDto
    {
        public Guid SurveyId { get; set; }

        public Guid QuestionId { get; set; }

        public string QuestionName { get; set; }

        public int? Point { get; set; }

        public string? Comment { get; set; }

        public bool IsQuestionComment { get; set; }
    }
}
