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

        public bool IsTeacher { get; set; }

        public bool IsStudent { get; set; }

        public List<Guid> ExistsIds { get; set; }
    }
}
