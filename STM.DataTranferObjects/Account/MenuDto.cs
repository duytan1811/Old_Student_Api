namespace STM.DataTranferObjects.Account
{
    using System.Collections.Generic;
    using STM.DataTranferObjects.Base;

    public class MenuDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string ParentKey { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public int Order { get; set; }

        public PermissionDto Permission { get; set; }

        public IEnumerable<MenuDto> MenuItems { get; set; }
    }
}
