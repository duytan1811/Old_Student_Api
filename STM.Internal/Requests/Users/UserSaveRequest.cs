namespace STM.API.Requests.Users
{
    using STM.API.Requests.Base;

    public class UserSaveRequest : BaseSaveRequest
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public bool IsDefaultPassword { get; set; }

        public string Email { get; set; }
    }
}
