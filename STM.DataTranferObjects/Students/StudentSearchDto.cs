namespace STM.DataTranferObjects.Students
{
    using STM.DataTranferObjects.Base;

    public class StudentSearchDto : BaseSearchDto
    {
        public string? Email { get; set; }

        public string? JobTitle { get; set; }

        public string? MajorId { get; set; }

        public string? Phone { get; set; }

        public string? FullName { get; set; }

        public int? SchoolYear { get; set; }

        public int? YearOfGraduation { get; set; }
    }
}
