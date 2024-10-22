namespace STM.DataTranferObjects.Questions
{
    using STM.DataTranferObjects.Base;

    public class QuestionSaveDto : BaseSaveDto
    {
        public string Name { get; set; }

        public bool IsComment { get; set; }
    }
}
