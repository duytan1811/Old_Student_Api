namespace STM.API.Requests.Questions
{
    using STM.API.Requests.Base;

    public class QuestionSaveRequestDto : BaseSaveRequest
    {
        public string Name { get; set; }

        public bool IsComment { get; set; }
    }
}
