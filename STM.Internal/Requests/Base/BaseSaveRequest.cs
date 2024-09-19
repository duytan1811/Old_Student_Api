namespace STM.API.Requests.Base
{
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class BaseSaveRequest
    {
        public string? Id { get; set; }

        public int? Status { get; set; } = StatusEnum.Active.AsInt();
    }
}
