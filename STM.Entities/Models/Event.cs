namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using STM.Common.Enums;

    [Table("Events")]
    public class Event : BaseModel
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public EventTypeEnum Type { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string? Content { get; set; }

        public virtual ICollection<EventRegister> EventRegisters { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
