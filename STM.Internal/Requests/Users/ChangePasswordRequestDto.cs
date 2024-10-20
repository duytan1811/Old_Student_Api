namespace STM.API.Requests.Users
{
    public class ChangePasswordRequestDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
