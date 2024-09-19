namespace STM.ViewModels.Accounts
{
    using System.Collections.Generic;
    using STM.API.Responses.Base;

    public class CurrentUserViewModel
    {
        public Guid Id { get; set; }

        public bool IsAdmin { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public List<PermissionMenuResponse> PermissionMenus { get; set; }
    }
}
