namespace STM.DataTranferObjects.News
{
    public class CommentSaveDto
    {
        public string Content { get; set; }

        public Guid NewsId { get; set; }

        public Guid UserId { get; set; }
    }
}
