namespace STM.API.Requests.Jobs
{
    public class JobSearchRequestDto
    {
        public string? FileName { get; set; }

        public Guid? MajorId { get; set; }

        public string? Title { get; set; }

        public int? Status { get; set; }

        public int? CountApply { get; set; }

        public Guid? CurentUserId { get; set; }
    }
}
