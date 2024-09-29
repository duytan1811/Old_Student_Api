namespace STM.API.Requests.News
{
    using STM.API.Requests.Base;
    using STM.Common.Enums;

    public class NewsSaveRequestDto : BaseSaveRequest
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
