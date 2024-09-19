namespace STM.API.Requests.Users
{
    public class UserSearchRequest
    {
        public UserSearchRequest()
        {
            this.ExistsIds = new List<Guid>();
        }

        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public int? Status { get; set; }

        public List<Guid> ExistsIds { get; set; }
    }
}
