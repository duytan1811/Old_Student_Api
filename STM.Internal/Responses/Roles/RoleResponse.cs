namespace STM.API.Responses.Roles
{
    using STM.API.Responses.Base;

    public class RoleResponse : BaseItemResponse
    {
        public string Name { get; set; }

        public int CountUsers { get; set; }
    }
}
