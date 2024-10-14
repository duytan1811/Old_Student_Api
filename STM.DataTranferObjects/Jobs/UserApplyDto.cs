namespace STM.DataTranferObjects.Jobs
{
    using STM.DataTranferObjects.Base;

    public class UserApplyDto : BaseDto
    {
        public Guid UserId { get; set; }

        public Guid JobId { get; set; }

        public string JobName { get; set; }

        public string? FullName { get; set; }

        public string? Content { get; set; }

        public string? FilePath { get; set; }
    }
}
