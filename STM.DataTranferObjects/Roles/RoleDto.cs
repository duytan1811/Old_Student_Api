namespace STM.DataTranferObjects.Roles
{
    using STM.DataTranferObjects.Base;

    public class RoleDto : BaseDto
    {
        public RoleDto()
        {
            this.MenuPermissions = new List<MenuPermissionDto>();
        }

        public string Name { get; set; }

        public int CountUsers { get; set; }

        public List<MenuPermissionDto>? MenuPermissions { get; set; }
    }
}
