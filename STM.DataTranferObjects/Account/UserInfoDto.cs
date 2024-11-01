﻿namespace STM.DataTranferObjects.Account
{
    using System.Collections.Generic;
    using STM.DataTranferObjects.Base;

    public class UserInfoDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public List<MenuDto> Menus { get; set; }

        public bool IsAdmin { get; set; }

        public string AdminText { get; set; }

        public List<PermissionMenuDto> PermissionMenus { get; set; }
    }
}
