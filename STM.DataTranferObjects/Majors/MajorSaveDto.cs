namespace STM.DataTranferObjects.Majors
{
    using STM.DataTranferObjects.Base;

    public class MajorSaveDto : BaseSaveDto
    {
        public string Name { get; set; }

        public Guid? AreaId { get; set; }
    }
}
