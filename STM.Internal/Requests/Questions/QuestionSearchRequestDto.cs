namespace STM.API.Requests.Questions
{
    using STM.Common.Enums;

    public class QuestionSearchRequestDto
    {
        public string? Name { get; set; }

        public bool? IsComment { get; set; }

        public StatusEnum? Status { get; set; }
    }
}
