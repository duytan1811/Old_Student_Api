namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Settings")]
    public class Setting : BaseModel
    {
        public string Type { get; set; }

        public string Key { get; set; }

        public string? Value { get; set; }
    }
}
