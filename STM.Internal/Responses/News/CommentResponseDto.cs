namespace STM.API.Responses.News
{
    using STM.API.Responses.Base;

    public class CommentResponseDto : BaseItemResponse
    {
        public Guid UserId { get; set; }

        public string CreatedByName { get; set; }

        public string? UserAvatar { get; set; }

        public string Content { get; set; }
    }
}
