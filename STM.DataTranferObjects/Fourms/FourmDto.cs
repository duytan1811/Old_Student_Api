namespace STM.DataTranferObjects.Fourms
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class FourmDto : BaseDto
    {
        public NewsTypeEnum Type { get; set; }

        public string CreatedByName { get; set; }

        public string? CreatedByAvatar { get; set; }

        public string Content { get; set; }

        public bool IsLiked { get; set; }

        public int? CountLike { get; set; }

        public int CountComment { get; set; }
    }
}
