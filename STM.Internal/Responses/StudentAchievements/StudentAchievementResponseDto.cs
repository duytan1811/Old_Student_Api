namespace STM.API.Responses.StudentAchievements
{
    using STM.API.Responses.Base;

    public class StudentAchievementResponseDto : BaseItemResponse
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FromDate { get; set; }

        public string? FromDateFormat => this.FromDate?.ToString("yyyy-MM-dd");

        public DateTime? ToDate { get; set; }

        public string? ToDateFormat => this.ToDate?.ToString("yyyy-MM-dd");
    }
}
