namespace STM.API.Responses.Students
{
    using STM.API.Responses.Base;
    using STM.Common.Enums;
    using STM.Common.Utilities;

    public class StudentResponseDto : BaseItemResponse
    {
        public StudentResponseDto()
        {
            this.Contributes = new List<StudentContributeResponseDto>();
        }

        public Guid? UserId { get; set; }

        public Guid? MajorId { get; set; }

        public string FullName { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Gender { get; set; }

        public string? Avatar { get; set; }

        public string? AvatarBase64 { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? SchoolYear { get; set; }

        public int? YearOfGraduation { get; set; }

        public string? CurrentCompany { get; set; }

        public string? JobTitle { get; set; }

        public string? MajorName { get; set; }

        public int? CountArchievement { get; set; }

        public int? CountContribute { get; set; }

        public List<StudentContributeResponseDto>? Contributes { get; set; }
    }

    public class StudentContributeResponseDto
    {
        public ContributeTypeEnum Type { get; set; }

        public string TypeName => EnumHelper<ContributeTypeEnum>.GetDisplayValue(this.Type);

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
