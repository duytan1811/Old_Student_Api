namespace STM.DataTranferObjects.Contributes
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class ContributeDto : BaseDto
    {
        public Guid StudentId { get; set; }

        public string FullName { get; set; }

        public ContributeTypeEnum Type { get; set; }

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
