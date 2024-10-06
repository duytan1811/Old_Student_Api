namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Jobs")]
    public class Job : BaseModel
    {
        public string Title { get; set; }

        public string? Content { get; set; }

        public Guid? MajorId { get; set; }

        public virtual Major Major { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string CompanyName { get; set; }

        public string? Skills { get; set; }

        public string? Address { get; set; }

        public int WorkType { get; set; }

        public string? FilePath { get; set; }
    }
}
