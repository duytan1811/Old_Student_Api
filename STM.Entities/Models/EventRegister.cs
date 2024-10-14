namespace STM.Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EventRegisters")]
    public class EventRegister : BaseModel
    {
        public Guid? EventId { get; set; }

        public virtual Event Event { get; set; }

        public Guid? UserId { get; set; }

        public virtual User User { get; set; }

        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
    }
}
