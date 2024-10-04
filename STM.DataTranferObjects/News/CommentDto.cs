namespace STM.DataTranferObjects.News
{
    using STM.DataTranferObjects.Base;

    public class CommentDto : BaseDto
    {
        public Guid UserId { get; set; }

        public string CreatedByName { get; set; }

        public string? UserAvatar { get; set; }

        public string Content { get; set; }
    }
}
