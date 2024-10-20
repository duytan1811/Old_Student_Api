namespace STM.DataTranferObjects.Email
{
    public class EmailInfoDto
    {
        public EmailInfoDto()
        {
            this.EmailAddress = new List<string>();
        }

        public string Title { get; set; }

        public List<string> EmailAddress { get; set; }

        public string Content { get; set; }

        public string FileName { get; set; }

        public int CurrentUserId { get; set; }
    }
}
