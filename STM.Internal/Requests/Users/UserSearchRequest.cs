namespace STM.API.Requests.Users
{
    using STM.Common.Enums;

    public class UserSearchRequest
    {
        public UserSearchRequest()
        {
            this.ExistsIds = new List<Guid>();
        }

        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public StatusEnum? Status { get; set; }

        public List<Guid> ExistsIds { get; set; }
    }
}
