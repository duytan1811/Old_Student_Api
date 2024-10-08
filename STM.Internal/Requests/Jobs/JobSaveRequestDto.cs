namespace STM.API.Requests.Jobs
{
    using STM.API.Requests.Base;

    public class JobSaveRequestDto : BaseSaveRequest
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public string? FileName { get; set; }

        public string CompanyName { get; set; }

        public List<string>? Skills { get; set; }

        public string? Address { get; set; }

        public int WorkType { get; set; }

        public string? FileBase64 { get; set; }
    }
}
