namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Surveys")]
    public class Survey : BaseModel
    {
        public Guid SurveyTemplateId { get; set; }

        public virtual SurveyTemplate SurveyTemplate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int MyProperty { get; set; }
    }
}
