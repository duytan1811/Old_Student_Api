namespace STM.API.Requests.News
{
    using STM.API.Requests.Base;
    using STM.Common.Enums;

    public class NewsSaveRequestDto : BaseSaveRequest
    {
        public NewsTypeEnum Type { get; set; }

        public string? Content { get; set; }

        public int? CountMember { get; set; }
    }
}
