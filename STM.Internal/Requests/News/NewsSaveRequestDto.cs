namespace STM.API.Requests.News
{
    using STM.API.Requests.Base;
    using STM.Common.Enums;

    public class NewsSaveRequestDto : BaseSaveRequest
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public NewsTypeEnum Type { get; set; }

        public string? Content { get; set; }

        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public int? CountMember { get; set; }
    }
}
