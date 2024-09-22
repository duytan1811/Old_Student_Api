namespace STM.API.Responses.StudentAchievements
{
    using STM.API.Responses.Base;

    public class StudentAchievementResponseDto : BaseItemResponse
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FormDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
