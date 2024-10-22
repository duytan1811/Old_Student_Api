namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Entities.Models;

    public class SurveyTemplateConfiguration : IEntityTypeConfiguration<SurveyTemplate>
    {
        public void Configure(EntityTypeBuilder<SurveyTemplate> builder)
        {
        }
    }
}