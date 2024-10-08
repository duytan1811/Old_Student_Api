namespace STM.DataTranferObjects.Jobs
{
    using STM.DataTranferObjects.Base;

    public class JobDto : BaseDto
    {
        public JobDto()
        {
            this.Skills = new List<string>();
        }

        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public string? MajorName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? FilePath { get; set; }

        public string CompanyName { get; set; }

        public List<string>? Skills { get; set; }

        public string? Address { get; set; }

        public int WorkType { get; set; }

        public bool IsApplyed { get; set; }
    }
}
