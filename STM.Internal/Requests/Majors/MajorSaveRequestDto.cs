namespace STM.API.Requests.Majors
{
    using STM.API.Requests.Base;

    public class MajorSaveRequestDto : BaseSaveRequest
    {
        public string Name { get; set; }

        public Guid? AreaId { get; set; }
    }
}
