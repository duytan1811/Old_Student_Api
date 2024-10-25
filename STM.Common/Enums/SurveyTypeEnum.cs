﻿namespace STM.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum SurveyTypeEnum
    {
        [Display(Name = "Hội thảo", Order = 1)]
        Seminar = 1,

        [Display(Name = "Gặp gỡ cựu sinh viên", Order = 2)]
        AlumniMeeting = 2,

        [Display(Name = "Chương trình từ thiện", Order = 3)]
        CharityProgram = 3,
    }
}