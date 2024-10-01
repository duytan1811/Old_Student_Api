namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using STM.Common.Enums;

    [Table("News")]
    public class News : BaseModel
    {
        public NewsTypeEnum Type { get; set; }

        public string? Content { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<NewsComment> NewComments { get; set; }

        public virtual ICollection<UserLikeNews> UserLikeNews { get; set; }
    }
}
