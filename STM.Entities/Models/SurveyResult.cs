namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SurveyResults")]
    public class SurveyResult : BaseModel
    {
        public Guid SurveyId { get; set; }

        public virtual Survey Survey { get; set; }

        public Guid QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public int? Point { get; set; }

        public string? Comment { get; set; }
    }
}
