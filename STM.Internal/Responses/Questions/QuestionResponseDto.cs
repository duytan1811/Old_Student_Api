namespace STM.API.Responses.Questions
{
    using STM.API.Responses.Base;

    public class QuestionResponseDto : BaseItemResponse
    {
        public string Name { get; set; }

        public bool IsComment { get; set; }
    }
}
