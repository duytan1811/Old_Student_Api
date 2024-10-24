namespace STM.DataTranferObjects.Surveys
{
    using STM.DataTranferObjects.Base;

    public class SurveyResultDto : BaseDto
    {
        public Guid SurveyId { get; set; }

        public string FullName { get; set; }
    }
}
