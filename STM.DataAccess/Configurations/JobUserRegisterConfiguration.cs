namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Entities.Models;

    public class JobUserRegisterConfiguration : IEntityTypeConfiguration<JobUserRegister>
    {
        public void Configure(EntityTypeBuilder<JobUserRegister> builder)
        {
        }
    }
}
