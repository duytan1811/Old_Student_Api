namespace STM.DataTranferObjects.Surveys
{
    using STM.DataTranferObjects.Base;

    public class SurveySaveDto : BaseSaveDto
    {
        public string Name { get; set; }

        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public List<Guid>? QuestionIds { get; set; }
    }
}
