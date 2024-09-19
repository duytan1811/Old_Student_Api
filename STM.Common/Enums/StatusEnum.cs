namespace STM.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum StatusEnum
    {
        /// <summary>
        /// Inactive.
        /// </summary>
        Inactive = 0,

        /// <summary>
        /// Active.
        /// </summary>
        [Display]
        Active = 1,

        /// <summary>
        /// In progress.
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// Cancel.
        /// </summary>
        Cancel = 3,
    }
}
