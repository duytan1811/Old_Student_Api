﻿namespace STM.DataTranferObjects.Users
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class UserSaveDto : BaseSaveDto
    {
        public string UserName { get; set; }

        public string? FullName { get; set; }

        public string Password { get; set; }

        public bool IsDefaultPassword { get; set; }

        public bool IsTeacher { get; set; }

        public string Email { get; set; }

        public UserTypeEnum? UserType { get; set; }
    }
}
