namespace STM.API.Requests.Jobs
{
    public class ApplyJobSaveRequestDto
    {
        public Guid UserId { get; set; }

        public Guid JobId { get; set; }

        public string? FullName { get; set; }

        public string? Content { get; set; }

        public string? FileName { get; set; }

        public string? FileBase64 { get; set; }
    }
}
