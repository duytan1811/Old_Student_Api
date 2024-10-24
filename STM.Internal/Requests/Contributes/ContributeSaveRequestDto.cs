namespace STM.API.Requests.Contributes
{
    using STM.API.Requests.Base;
    using STM.Common.Enums;

    public class ContributeSaveRequestDto : BaseSaveRequest
    {
        public Guid StudentId { get; set; }

        public ContributeTypeEnum Type { get; set; }

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
