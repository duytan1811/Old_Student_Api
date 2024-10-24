namespace STM.API.Responses.Contributes
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class ContributeResponseDto : BaseItemResponse
    {
        public Guid StudentId { get; set; }

        public string FullName { get; set; }

        public ContributeTypeEnum Type { get; set; }

        public string TypeName => EnumHelper<ContributeTypeEnum>.GetDisplayValue(this.Type);

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
