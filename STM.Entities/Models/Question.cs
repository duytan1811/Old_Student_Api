namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Questions")]
    public class Question : BaseModel
    {
        public string Name { get; set; }

        public bool IsComment { get; set; }
    }
}
