namespace STM.API.Responses.Majors
{
    using STM.API.Responses.Base;

    public class MajorResponseDto : BaseItemResponse
    {
        public Guid? OrderId { get; set; }

        public int Order { get; set; }

        public bool IsProgress { get; set; }

        public string Name { get; set; }

        public Guid? AreaId { get; set; }

        public string? AreaName { get; set; }
    }
}
