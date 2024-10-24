namespace STM.DataTranferObjects.Contributes
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class ContributeSaveDto : BaseSaveDto
    {
        public Guid StudentId { get; set; }

        public ContributeTypeEnum Type { get; set; }

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
