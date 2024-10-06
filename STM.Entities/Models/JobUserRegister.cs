namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("JobUserRegisters")]
    public class JobUserRegister : BaseModel
    {
        public Guid? JobId { get; set; }

        public virtual Job Job { get; set; }

        public Guid? UserId { get; set; }

        public virtual User? User { get; set; }

        public string? Descriotion { get; set; }

        public string? FilePath { get; set; }
    }
}
