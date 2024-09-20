﻿namespace STM.DataTranferObjects.Students
{
    using STM.DataTranferObjects.Base;

    public class StudentDto : BaseDto
    {
        public Guid? UserId { get; set; }

        public Guid? MajorId { get; set; }

        public string FullName { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Gender { get; set; }

        public string? Avatar { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? SchoolYear { get; set; }

        public int? YearOfGraduation { get; set; }

        public string? CurrentCompany { get; set; }

        public string? JobTitle { get; set; }
    }
}