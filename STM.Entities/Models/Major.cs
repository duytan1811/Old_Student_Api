namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Majors")]
    public class Major : BaseModel
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
