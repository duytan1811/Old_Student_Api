namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SystemLogs")]
    public class SystemLog : BaseModel
    {
        public string? Object { get; set; }

        public string? Action { get; set; }

        public string? Content { get; set; }

        public string? Note { get; set; }
    }
}
