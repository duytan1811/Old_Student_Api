namespace STM.DataTranferObjects.Jobs
{
    using STM.DataTranferObjects.Base;

    public class JobSearchDto : BaseSearchDto
    {
        public string? FileName { get; set; }

        public Guid? MajorId { get; set; }

        public string? Title { get; set; }

        public int? CountApply { get; set; }

        public Guid? CurrentUserId { get; set; }
    }
}
