namespace STM.DataTranferObjects.SurveyTemplates
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class SurveyTemplateSaveDto : BaseSaveDto
    {
        public string Name { get; set; }

        public SurveyTypeEnum Type { get; set; }

        public List<Guid>? QuestionIds { get; set; }
    }
}
