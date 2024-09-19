namespace STM.DataTranferObjects.Roles
{
    using STM.DataTranferObjects.Base;

    public class RoleDto : BaseDto
    {
        public RoleDto()
        {
        }

        public string Name { get; set; }

        public int CountUsers { get; set; }
    }
}
