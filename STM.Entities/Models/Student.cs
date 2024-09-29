namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Student : BaseModel
    {
        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }

        public Guid? MajorId { get; set; }

        public virtual Major? Major { get; set; }

        public string FullName { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Gender { get; set; }

        public string? Avatar { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? SchoolYear { get; set; }

        public int? YearOfGraduation { get; set; }

        public string? CurrentCompany { get; set; }

        public string? JobTitle { get; set; }

        public virtual ICollection<StudentAchievement>? StudentAchievements { get; set; }
    }
}
