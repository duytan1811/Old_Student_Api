namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using STM.Common.Enums;

    [Table("Contributes")]
    public class Contribute : BaseModel
    {
        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; }

        public ContributeTypeEnum Type { get; set; }

        public decimal? Amount { get; set; }

        public string? Detail { get; set; }
    }
}
