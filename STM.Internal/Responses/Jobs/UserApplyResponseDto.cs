namespace STM.API.Responses.Jobs
{
    using STM.API.Responses.Base;

    public class UserApplyResponseDto : BaseItemResponse
    {
        public Guid UserId { get; set; }

        public Guid JobId { get; set; }

        public string JobName { get; set; }

        public string? FullName { get; set; }

        public string? Content { get; set; }

        public string? FilePath { get; set; }

        public string? FileName => !string.IsNullOrEmpty(this.FilePath) ? this.FilePath.Split("/")[5] : null;
    }
}
