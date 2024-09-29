namespace STM.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum NewTypeEnum
    {
        [Display(Name = "Tin tức công nghệ", Order = 2)]
        TechNew = 1,

        [Display(Name = "Sự kiện hội ngộ", Order = 2)]
        ReunionEvent = 2,

        [Display(Name = "Thông tin học bổng", Order = 2)]
        ScholarshipInformation = 3,

        [Display(Name = "Cơ hội việc làm", Order = 2)]
        JobOpportunities = 4,
    }
}
