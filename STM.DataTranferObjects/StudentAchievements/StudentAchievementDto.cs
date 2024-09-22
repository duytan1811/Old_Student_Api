﻿namespace STM.DataTranferObjects.StudentAchievements
{
    using STM.DataTranferObjects.Base;

    public class StudentAchievementDto : BaseDto
    {
        public Guid? StudentId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
