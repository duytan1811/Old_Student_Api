namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("StudentAchievements")]
    public class StudentAchievement : BaseModel
    {
        public Guid? StudentId { get; set; }

        public virtual Student? Student { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }
    }
}
