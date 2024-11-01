namespace STM.API.Requests.Students
{
    using STM.API.Requests.Base;

    public class StudentSaveRequestDto : BaseSaveRequest
    {
        public Guid? MajorId { get; set; }

        public string FullName { get; set; }

        public string? Birthday { get; set; }

        public int? Gender { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? SchoolYear { get; set; }

        public int? YearOfGraduation { get; set; }

        public string? CurrentCompany { get; set; }

        public string? JobTitle { get; set; }

        public string? FileName { get; set; }

        public string? FileBase64 { get; set; }
    }
}
