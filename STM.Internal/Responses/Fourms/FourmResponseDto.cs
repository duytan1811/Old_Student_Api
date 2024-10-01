namespace STM.API.Responses.Fourms
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class FourmResponseDto : BaseItemResponse
    {
        public NewsTypeEnum Type { get; set; }

        public string TypeName => EnumHelper<NewsTypeEnum>.GetDisplayValue(this.Type);

        public string CreatedByName { get; set; }

        public string? CreatedByAvatar { get; set; }

        public string Content { get; set; }

        public bool IsLiked { get; set; }

        public int? CountLike { get; set; }

        public int CountComment { get; set; }
    }
}
