namespace STM.API.Requests.Jobs
{
    public class JobSearchRequestDto
    {
        public string? Title { get; set; }

        public int? Status { get; set; }

        public Guid? CurentUserId { get; set; }
    }
}
