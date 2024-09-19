namespace STM.API.Responses.Base
{
    public class PermissionResponse
    {
        public bool IsView { get; set; }

        public bool IsCreate { get; set; }

        public bool IsEdit { get; set; }

        public bool IsDelete { get; set; }
    }
}
