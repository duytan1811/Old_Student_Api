namespace STM.DataTranferObjects.Surveys
{
    using STM.DataTranferObjects.Base;

    public class SurveyResultSearchDto : BaseSearchDto
    {
        public Guid? SurveyId { get; set; }

        public string? FullName { get; set; }

        public DateTime? Date { get; set; }
    }
}
