namespace STM.API.Requests.Roles
{
    using STM.Common.Enums;

    public class RoleSearchRequest
    {
        public StatusEnum? Status { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }
}
