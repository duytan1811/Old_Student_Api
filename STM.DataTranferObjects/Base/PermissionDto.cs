﻿namespace STM.DataTranferObjects.Base
{
    public class PermissionDto
    {
        public bool IsView { get; set; }

        public bool IsCreate { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }
    }
}
