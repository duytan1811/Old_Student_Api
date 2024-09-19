namespace STM.DataTranferObjects.Base
{
    public class PermissionMenuDto
    {
        public PermissionMenuDto()
        {
            this.Permission = new PermissionDto();
        }

        public string MenuKey { get; set; }

        public PermissionDto Permission { get; set; }
    }
}
