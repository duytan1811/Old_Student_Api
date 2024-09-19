namespace STM.DataTranferObjects.Users
{
    using STM.DataTranferObjects.Base;

    public class UserDto : BaseDto
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
