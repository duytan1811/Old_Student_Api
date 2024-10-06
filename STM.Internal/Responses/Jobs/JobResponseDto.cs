namespace STM.API.Responses.Jobs
{
    using STM.API.Responses.Base;

    public class JobResponseDto : BaseItemResponse
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public string? MajorName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string CompanyName { get; set; }

        public string? Skills { get; set; }

        public string? Address { get; set; }

        public int WorkType { get; set; }

        public string? FilePath { get; set; }

        public string? FileName => !string.IsNullOrEmpty(this.FilePath) ? this.FilePath.Split("/")[3] : null;
    }
}
