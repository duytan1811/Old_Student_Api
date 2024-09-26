﻿namespace STM.API.Responses.Users
{
    using STM.API.Responses.Base;
    using STM.DataTranferObjects.Roles;

    public class UserResponse : BaseItemResponse
    {
        public bool IsAdmin { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }

        public List<MenuPermissionDto> MenuPermissions { get; set; }
    }
}
