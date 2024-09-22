namespace STM.API.Requests.StudentAchievements
{
    using STM.API.Requests.Base;

    public class StudentAchievementSaveRequestDto : BaseSaveRequest
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
