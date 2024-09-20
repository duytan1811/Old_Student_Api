namespace STM.API.Requests.Students
{
    using STM.API.Requests.Base;

    public class StudentSaveRequestDto : BaseSaveRequest
    {
        public Guid? MajorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public int Gender { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string SchoolYear { get; set; }

        public string YearOfGraduation { get; set; }

        public string CurrentCompany { get; set; }

        public string JobTitle { get; set; }
    }
}
