namespace STM.API.Requests.Roles
{
    using STM.API.Requests.Base;
    using STM.DataTranferObjects.Roles;

    public class RoleSaveRequest : BaseSaveRequest
    {
        public RoleSaveRequest()
        {
            this.MenuPermissions = new List<MenuPermissionDto>();
        }

        public string? Code { get; set; }

        public string Name { get; set; }

        public List<MenuPermissionDto>? MenuPermissions { get; set; }
    }
}
