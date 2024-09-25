namespace STM.API.Responses.Roles
{
    using STM.API.Responses.Base;
    using STM.DataTranferObjects.Roles;

    public class RoleResponse : BaseItemResponse
    {
        public RoleResponse()
        {
            this.MenuPermissions = new List<MenuPermissionDto>();
        }

        public string Name { get; set; }

        public int CountUsers { get; set; }

        public List<MenuPermissionDto>? MenuPermissions { get; set; }
    }
}
