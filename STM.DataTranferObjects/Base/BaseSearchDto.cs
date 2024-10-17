namespace STM.DataTranferObjects.Base
{
    using STM.Common.Enums;

    public class BaseSearchDto
    {
        public StatusEnum? Status { get; set; }

        public string Column { get; set; }

        public string Direction { get; set; }

        public bool Ascending => this.Direction == "asc";
    }
}
