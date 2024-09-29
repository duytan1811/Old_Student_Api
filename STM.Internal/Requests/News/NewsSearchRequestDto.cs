namespace STM.API.Requests.News
{
    using STM.Common.Enums;

    public class NewsSearchRequestDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public NewTypeEnum Type { get; set; }
    }
}
