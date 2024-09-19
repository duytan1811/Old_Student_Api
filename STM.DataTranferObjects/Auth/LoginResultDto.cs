namespace STM.DataTranferObjects.Auth
{
    public class LoginResultDto
    {
        public bool Succeeded { get; set; }

        public bool IsLockedOut { get; set; }

        public bool WillBeLocked { get; set; }
    }
}
