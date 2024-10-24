namespace STM.API.Requests.Contributes
{
    using STM.Common.Enums;

    public class ContributeSearchRequestDto
    {
        public string? FullName { get; set; }

        public ContributeTypeEnum Type { get; set; }

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
