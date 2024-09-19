namespace STM.DataTranferObjects.Users
{
    using STM.DataTranferObjects.Base;

    public class UserSearchDto : BaseSearchDto
    {
        public UserSearchDto()
        {
            this.ExistsIds = new List<Guid>();
        }

        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public List<Guid> ExistsIds { get; set; }
    }
}
