namespace STM.DataTranferObjects.Questions
{
    using STM.DataTranferObjects.Base;

    public class QuestionDto : BaseDto
    {
        public string Name { get; set; }

        public bool IsComment { get; set; }
    }
}
