namespace STM.DataTranferObjects.Roles
{
    using STM.DataTranferObjects.Base;

    public class RoleSearchDto : BaseSearchDto
    {
        public string? UserName { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }
}
