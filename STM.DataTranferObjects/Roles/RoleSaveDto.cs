namespace STM.DataTranferObjects.Roles
{
    using STM.DataTranferObjects.Base;

    public class RoleSaveDto : BaseSaveDto
    {
        public RoleSaveDto()
        {
            this.MenuPermissions = new List<MenuPermissionDto>();
        }

        public string Name { get; set; }

        public List<MenuPermissionDto>? MenuPermissions { get; set; }
    }

    public class MenuPermissionDto
    {
        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public bool IsView { get; set; }

        public bool IsCreate { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }
    }
}
