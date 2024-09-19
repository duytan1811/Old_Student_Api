namespace STM.API.Requests.Roles
{
    using STM.API.Requests.Base;

    public class RoleSaveRequest : BaseSaveRequest
    {
        public string? Code { get; set; }

        public string Name { get; set; }
    }
}
