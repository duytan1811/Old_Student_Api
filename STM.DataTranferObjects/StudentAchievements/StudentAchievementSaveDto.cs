namespace STM.DataTranferObjects.StudentAchievements
{
    using STM.DataTranferObjects.Base;

    public class StudentAchievementSaveDto : BaseSaveDto
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FormDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
