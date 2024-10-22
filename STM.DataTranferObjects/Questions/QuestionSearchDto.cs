namespace STM.DataTranferObjects.Questions
{
    using STM.DataTranferObjects.Base;

    public class QuestionSearchDto : BaseSearchDto
    {
        public string? Name { get; set; }

        public bool? IsComment { get; set; }
    }
}
