namespace STM.API.Requests.SurveyTemplates
{
    using STM.API.Requests.Base;
    using STM.Common.Enums;

    public class SurveyTemplateSaveRequestDto : BaseSaveRequest
    {
        public SurveyTemplateSaveRequestDto()
        {
            this.QuestionIds = new List<Guid>();
        }

        public string Name { get; set; }

        public SurveyTypeEnum Type { get; set; }

        public List<Guid>? QuestionIds { get; set; }
    }
}
