namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Entities.Models;

    public class StudentAchievementConfigurarion : IEntityTypeConfiguration<StudentAchievement>
    {
        public void Configure(EntityTypeBuilder<StudentAchievement> builder)
        {
        }
    }
}