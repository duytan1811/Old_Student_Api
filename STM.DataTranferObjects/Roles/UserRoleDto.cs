namespace STM.DataTranferObjects.Roles
{
    public class UserRoleDto
    {
        public Guid UserId { get; set; }

        public string FullName { get; set; }

        public bool HasRole { get; set; }
    }
}
