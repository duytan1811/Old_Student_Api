namespace STM.DataTranferObjects.Jobs
{
    using STM.DataTranferObjects.Base;

    public class JobDto : BaseDto
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public string? MajorName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? FilePath { get; set; }
    }
}
