namespace STM.DataTranferObjects.Surveys
{
    using STM.DataTranferObjects.Base;

    public class SurveySearchDto : BaseSearchDto
    {
        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? CurrentUserId { get; set; }
    }
}
