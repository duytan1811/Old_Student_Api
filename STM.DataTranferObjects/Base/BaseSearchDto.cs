namespace STM.DataTranferObjects.Base
{
    public class BaseSearchDto
    {
        public int? Status { get; set; }

        public string Column { get; set; }

        public string Direction { get; set; }

        public bool Ascending => this.Direction == "asc";
    }
}
