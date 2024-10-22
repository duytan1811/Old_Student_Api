namespace STM.API.Responses.SurveyTemplates
{
    using STM.API.Responses.Base;

    public class SurveyTemplateResponseDto : BaseItemResponse
    {
        public SurveyTemplateResponseDto()
        {
            this.QuestionIds = new List<Guid>();
        }

        public string Name { get; set; }

        public List<Guid>? QuestionIds { get; set; }
    }
}
