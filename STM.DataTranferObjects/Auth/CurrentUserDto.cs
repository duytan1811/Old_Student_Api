namespace STM.DataTranferObjects.Auth
{
    using STM.DataTranferObjects.Base;
    using STM.DataTranferObjects.Roles;

    public class CurrentUserDto : BaseDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public List<string> RoleNames { get; set; }

        public List<MenuPermissionDto>? MenuPermissions { get; set; }
    }
}
