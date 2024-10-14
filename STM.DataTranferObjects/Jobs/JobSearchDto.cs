namespace STM.DataTranferObjects.Jobs
{
    using STM.DataTranferObjects.Base;

    public class JobSearchDto : BaseSearchDto
    {
        public string? Title { get; set; }

        public Guid? CurrentUserId { get; set; }
    }
}
