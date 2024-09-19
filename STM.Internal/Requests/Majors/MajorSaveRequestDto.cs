namespace STM.API.Requests.Tables
{
    using STM.API.Requests.Base;

    public class MajorSaveRequestDto : BaseSaveRequest
    {
        public string Name { get; set; }

        public Guid? AreaId { get; set; }
    }
}
