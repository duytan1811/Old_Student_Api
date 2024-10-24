namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Entities.Models;

    public class ContributeConfiguration : IEntityTypeConfiguration<Contribute>
    {
        public void Configure(EntityTypeBuilder<Contribute> builder)
        {
        }
    }
}