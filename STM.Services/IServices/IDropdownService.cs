namespace STM.Services.IServices
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IDropdownService
    {
        Task<List<SelectListItem>> GetUsers();
    }
}
