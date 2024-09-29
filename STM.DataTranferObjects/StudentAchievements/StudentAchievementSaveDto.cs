namespace STM.DataTranferObjects.StudentAchievements
{
    using STM.DataTranferObjects.Base;

    public class StudentAchievementSaveDto : BaseSaveDto
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? FromDateFormat { get; set; }

        public string? ToDateFormat { get; set; }
    }
}
