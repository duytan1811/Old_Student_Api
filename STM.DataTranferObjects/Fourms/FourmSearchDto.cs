namespace STM.DataTranferObjects.Fourms
{
    using STM.Common.Enums;
    using STM.DataTranferObjects.Base;

    public class FourmSearchDto : BaseSearchDto
    {
        public NewsTypeEnum? Type { get; set; }
    }
}
