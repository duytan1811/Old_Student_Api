namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Email;

    public interface IEmailService
    {
        public bool SendMail(EmailInfoDto emailInfo);
    }
}
