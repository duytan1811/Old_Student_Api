namespace STM.DataTranferObjects.News
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class NewsSaveDto : BaseSaveDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public NewsTypeEnum Type { get; set; }

        public string? Content { get; set; }

        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public int? CountMember { get; set; }

        public Guid? CurrentUserId { get; set; }
    }
}
