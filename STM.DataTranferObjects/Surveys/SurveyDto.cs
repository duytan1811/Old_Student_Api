namespace STM.DataTranferObjects.Surveys
{
    using STM.DataTranferObjects.Base;
    using STM.DataTranferObjects.Questions;

    public class SurveyDto : BaseDto
    {
        public SurveyDto()
        {
            this.QuestionIds = new List<Guid>();
            this.Questions = new List<QuestionDto>();
        }

        public string Name { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<Guid>? QuestionIds { get; set; }

        public List<QuestionDto>? Questions { get; set; }

        public bool IsSurveyed { get; set; }

        public int CountSurveyed { get; set; }
    }
}
