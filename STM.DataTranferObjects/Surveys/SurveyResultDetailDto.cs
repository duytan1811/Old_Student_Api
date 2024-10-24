namespace STM.DataTranferObjects.Surveys
{
    using STM.DataTranferObjects.Base;

    public class SurveyResultDetailDto : BaseDto
    {
        public SurveyResultDetailDto()
        {
            this.Items = new List<SurveyResultDetailItemDto>();
        }

        public string CreatedByName { get; set; }

        public List<SurveyResultDetailItemDto>? Items { get; set; }
    }

    public class SurveyResultDetailItemDto
    {
        public Guid SurveyId { get; set; }

        public Guid QuestionId { get; set; }

        public string QuestionName { get; set; }

        public int? Point { get; set; }

        public string? Comment { get; set; }

        public bool IsQuestionComment { get; set; }
    }
}
