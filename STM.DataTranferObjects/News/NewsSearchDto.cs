namespace STM.DataTranferObjects.News
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class NewsSearchDto : BaseSearchDto
    {
        public string? Content { get; set; }

        public int? CountLike { get; set; }

        public int? CountComment { get; set; }

        public NewsTypeEnum? Type { get; set; }
    }
}
