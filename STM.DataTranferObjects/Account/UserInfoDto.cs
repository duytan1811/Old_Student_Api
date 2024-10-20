namespace STM.DataTranferObjects.Account
{
    using System.Collections.Generic;
    using STM.DataTranferObjects.Roles;

    public class UserInfoDto
    {
        public Guid Id { get; set; }

        public Guid? StudentId { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public List<MenuDto> Menus { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsTeacher { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public List<MenuPermissionDto> MenuPermissions { get; set; }
    }
}
