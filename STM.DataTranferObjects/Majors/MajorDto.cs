namespace STM.DataTranferObjects.Majors
{
    using STM.DataTranferObjects.Base;

    public class MajorDto : BaseDto
    {
        public Guid? OrderId { get; set; }

        public int? Order { get; set; }

        public string Name { get; set; }

        public Guid? AreaId { get; set; }

        public string? AreaName { get; set; }

        public bool IsProgress { get; set; }
    }
}
