namespace STM.DataTranferObjects.StudentAchievements
{
    using STM.DataTranferObjects.Base;

    public class StudentAchievementSearchDto : BaseSearchDto
    {
        public string? Name { get; set; }

        public Guid? StudentId { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
