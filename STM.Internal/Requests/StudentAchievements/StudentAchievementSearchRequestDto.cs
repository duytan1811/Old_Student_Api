namespace STM.API.Requests.StudentAchievements
{
    public class StudentAchievementSearchRequestDto
    {
        public string? Name { get; set; }

        public Guid? StudentId { get; set; }

        public DateTime? FormDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
