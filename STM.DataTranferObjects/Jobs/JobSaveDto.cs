namespace STM.DataTranferObjects.Jobs
{
    using STM.DataTranferObjects.Base;

    public class JobSaveDto : BaseSaveDto
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public string? StartDateFormat { get; set; }

        public string? EndDateFormat { get; set; }

        public string? FileName { get; set; }

        public string? FileBase64 { get; set; }

        public bool IsDeleteFile { get; set; }

        public string CompanyName { get; set; }

        public string? Skills { get; set; }

        public string? Address { get; set; }

        public int WorkType { get; set; }
    }
}
