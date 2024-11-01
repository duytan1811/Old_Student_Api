namespace STM.DataTranferObjects.Students
{
    using STM.DataTranferObjects.Base;

    public class StudentSaveDto : BaseSaveDto
    {
        public Guid? MajorId { get; set; }

        public string FullName { get; set; }

        public string? BirthdayFormat { get; set; }

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
