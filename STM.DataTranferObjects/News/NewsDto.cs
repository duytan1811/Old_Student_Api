namespace STM.DataTranferObjects.News
{
    using STM.DataTranferObjects.Base;

    public class NewsDto : BaseDto
    {
        public string Type { get; set; }

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CountLike { get; set; }

        public int? CountComment { get; set; }

        public string? CreatedByAvatar { get; set; }

        public string? CreatedByName { get; set; }

        public bool IsLiked { get; set; }
    }
}
