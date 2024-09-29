namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using STM.Common.Enums;

    [Table("News")]
    public class News : BaseModel
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public NewsTypeEnum Type { get; set; }

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CountMember { get; set; }

        public virtual ICollection<NewsComment> NewComments { get; set; }
    }
}
