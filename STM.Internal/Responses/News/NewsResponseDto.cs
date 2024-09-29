namespace STM.API.Responses.News
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;

    public class NewsResponseDto : BaseItemResponse
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public NewTypeEnum Type { get; set; }

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CountMember { get; set; }
    }
}
