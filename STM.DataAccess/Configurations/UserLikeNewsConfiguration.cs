namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Entities.Models;

    internal class UserLikeNewsConfiguration : IEntityTypeConfiguration<UserLikeNews>
    {
        public void Configure(EntityTypeBuilder<UserLikeNews> builder)
        {
        }
    }
}
