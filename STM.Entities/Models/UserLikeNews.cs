namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserLikeNews")]
    public class UserLikeNews : BaseModel
    {
        public Guid UserId { get; set; }

        public Guid NewsId { get; set; }

        public virtual News News { get; set; }
    }
}
