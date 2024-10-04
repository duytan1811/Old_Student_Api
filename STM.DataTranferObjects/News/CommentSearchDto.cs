namespace STM.DataTranferObjects.News
{
    using STM.DataTranferObjects.Base;

    public class CommentSearchDto : BaseSearchDto
    {
        public Guid NewsId { get; set; }
    }
}
