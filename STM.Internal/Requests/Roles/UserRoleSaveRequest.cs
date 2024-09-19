namespace STM.API.Requests.Roles
{
    using System.Collections.Generic;

    public class UserRoleSaveRequest
    {
        public Guid RoleId { get; set; }

        public List<Guid> UserIds { get; set; }
    }
}
