namespace STM.API.Requests.News
{
    using STM.Common.Enums;

    public class NewsSearchRequestDto
    {
        public string? Content { get; set; }

        public int? CountLike { get; set; }

        public int? CountComment { get; set; }

        public NewsTypeEnum? Type { get; set; }

        public StatusEnum? Status { get; set; }
    }
}
