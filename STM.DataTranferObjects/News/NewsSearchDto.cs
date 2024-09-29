namespace STM.DataTranferObjects.News
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class NewsSearchDto : BaseSearchDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public NewTypeEnum Type { get; set; }
    }
}
