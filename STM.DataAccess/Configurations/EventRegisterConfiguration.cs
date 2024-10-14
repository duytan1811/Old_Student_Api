namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Entities.Models;

    public class EventRegisterConfiguration : IEntityTypeConfiguration<EventRegister>
    {
        public void Configure(EntityTypeBuilder<EventRegister> builder)
        {
        }
    }
}