namespace STM.DataTranferObjects.Majors
{
    using Microsoft.AspNetCore.Http;

    public class MajorImportDto
    {
        public IFormFile? File { get; set; }
    }
}
