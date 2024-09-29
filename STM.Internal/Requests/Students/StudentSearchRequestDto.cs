namespace STM.API.Requests.Students
{
    public class StudentSearchRequestDto
    {
        public int? SchoolYear { get; set; }

        public int? YearOfGraduation { get; set; }

        public string? JobTitle { get; set; }

        public string? MajorId { get; set; }

        public string? Phone { get; set; }

        public string? FullName { get; set; }
    }
}
