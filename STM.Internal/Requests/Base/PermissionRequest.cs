namespace STM.API.Requests.Base
{
    public class PermissionRequest
    {
        public bool IsView { get; set; }

        public bool IsCreate { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }
    }
}
