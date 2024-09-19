namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students")]
    public class Student : BaseModel
    {
        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }

        public Guid? MajorId { get; set; }

        public virtual Major Major { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Birthday { get; set; }

        public int Gender { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string SchoolYear { get; set; }

        public string YearOfGraduation { get; set; }

        public string CurrentCompany { get; set; }

        public string JobTitle { get; set; }
    }
}
