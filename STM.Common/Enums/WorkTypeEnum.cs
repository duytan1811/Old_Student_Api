namespace STM.Common.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum WorkTypeEnum
    {
        [Display(Name = "Tại văn phòng", Order = 1)]
        Office = 1,

        [Display(Name = "Làm việc từ xa", Order = 2)]
        Remote = 2,

        [Display(Name = "Linh hoạt", Order = 3)]
        Hybrid = 3,
    }
}
