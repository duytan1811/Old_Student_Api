namespace STM.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum StatusEnum
    {
        /// <summary>
        /// Inactive.
        /// </summary>
        [Display(Name = "Không hoạt động", Order = 2)]
        Inactive = 0,

        /// <summary>
        /// Active.
        /// </summary>
        [Display(Name = "Hoạt động", Order = 2)]
        Active = 1,

        /// <summary>
        /// In progress.
        /// </summary>
        [Display(Name = "Đang xử lý", Order = 2)]
        InProgress = 2,

        /// <summary>
        /// Cancel.
        /// </summary>
        [Display(Name = "Hủy bỏ", Order = 2)]
        Cancel = 3,
    }
}
