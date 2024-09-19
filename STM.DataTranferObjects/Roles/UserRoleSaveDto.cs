namespace STM.DataTranferObjects.Roles
{
    public class UserRoleSaveDto
    {
        public UserRoleSaveDto()
        {
            this.UserIds = new List<Guid>();
        }

        public Guid RoleId { get; set; }

        public List<Guid> UserIds { get; set; }
    }
}
