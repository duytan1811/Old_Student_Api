namespace STM.API.Responses.Roles
{
    using STM.API.Responses.Base;

    public class RoleResponse : BaseItemResponse
    {
        public RoleResponse()
        {
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public int CountUsers { get; set; }

        public List<string> PermissionMenusString { get; set; }
    }
}
