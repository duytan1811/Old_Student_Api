namespace STM.API.Requests.News
{
    public class CommentSaveRequestDto
    {
        public string Content { get; set; }

        public Guid NewsId { get; set; }

        public Guid UserId { get; set; }
    }
}
