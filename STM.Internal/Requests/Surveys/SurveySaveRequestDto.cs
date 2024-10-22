namespace STM.API.Requests.Surveys
{
    using STM.API.Requests.Base;

    public class SurveySaveRequestDto : BaseSaveRequest
    {
        public SurveySaveRequestDto()
        {
            this.QuestionIds = new List<Guid>();
        }

        public string Name { get; set; }

        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public List<Guid>? QuestionIds { get; set; }
    }
}
