namespace STM.ViewModels.Accounts
{
    using STM.DataTranferObjects.Roles;

    public class CurrentUserViewModel
    {
        public Guid Id { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsTeacher { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public List<MenuPermissionDto>? MenuPermissions { get; set; }
    }
}
