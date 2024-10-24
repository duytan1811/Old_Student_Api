namespace STM.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ContributeTypeEnum
    {
        [Display(Name = "Quên góp tài chính", Order = 1)]
        FinancialDonation = 1,

        [Display(Name = "Hỗ trợ giáo dục và đào tạo", Order = 2)]
        EducationalSupport = 2,
    }
}
