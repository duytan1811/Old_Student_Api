namespace STM.DataTranferObjects.SurveyTemplates
{
    using STM.DataTranferObjects.Base;

    public class SurveyTemplateDto : BaseDto
    {
        public SurveyTemplateDto()
        {
            this.QuestionIds = new List<Guid>();
        }

        public string Name { get; set; }

        public List<Guid>? QuestionIds { get; set; }
    }
}
