namespace STM.DataTranferObjects.Users
{
    using STM.DataTranferObjects.Base;

    public class UserSaveDto : BaseSaveDto
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool IsDefaultPassword { get; set; }

        public string Email { get; set; }
    }
}
