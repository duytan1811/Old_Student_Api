namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Surveys")]
    public class Survey : BaseModel
    {
        public string Name { get; set; }

        public string? QuestionIds { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<SurveyResult> SurveyResults { get; set; }
    }
}
