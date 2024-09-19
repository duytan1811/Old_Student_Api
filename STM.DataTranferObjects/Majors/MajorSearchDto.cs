namespace STM.DataTranferObjects.Majors
{
    using STM.DataTranferObjects.Base;

    public class MajorSearchDto : BaseSearchDto
    {
        public string? Order { get; set; }

        public string? Name { get; set; }
    }
}
