namespace STM.DataTranferObjects.Surveys
{
    public class SurveyResultSaveDto
    {
        public SurveyResultSaveDto()
        {
            this.Questions = new List<SurveyResultSaveItemDto>();
        }

        public List<SurveyResultSaveItemDto> Questions { get; set; }
    }

    public class SurveyResultSaveItemDto
    {
        public Guid QuestionId { get; set; }

        public int? Point { get; set; }

        public string? Comment { get; set; }
    }
}
