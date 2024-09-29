namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NewComments")]
    public class NewsComment : BaseModel
    {
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid NewId { get; set; }

        public virtual News New { get; set; }

        public string Content { get; set; }
    }
}
