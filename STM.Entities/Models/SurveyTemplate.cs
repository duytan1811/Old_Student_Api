namespace STM.Entities.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using STM.Common.Enums;

    [Table("SurveyTemplate")]
    public class SurveyTemplate : BaseModel
    {
        public string Name { get; set; }

        public string? QuestionIds { get; set; }

        public SurveyTypeEnum Type { get; set; }
    }
}
