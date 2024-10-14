namespace STM.DataTranferObjects.Users
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class UserDto : BaseDto
    {
        public string UserName { get; set; }

        public string? FullName { get; set; }

        public string Email { get; set; }

        public bool IsTeacher { get; set; }

        public UserTypeEnum? UserType { get; set; }
    }
}
