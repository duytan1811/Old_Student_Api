namespace STM.API.Responses.News
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class NewsResponseDto : BaseItemResponse
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string Type { get; set; }

        public string TypeName => EnumHelper<NewsTypeEnum>.GetDisplayValue(this.Type);

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public string? StartDateFormat => this.StartDate?.ToString("yyyy-MM-dd");

        public DateTime? EndDate { get; set; }

        public string? EndDateFormat => this.EndDate?.ToString("yyyy-MM-dd");

        public int? CountMember { get; set; }
    }
}
