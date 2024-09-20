namespace STM.DataAccess.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using STM.Common.Constants;
    using STM.Common.Enums;
    using STM.Entities.Models;

    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            foreach (var settingType in SettingConstants.Types.TypeList)
            {
                var settingKeys = SettingConstants.GetSetingKeyOfType(settingType);

                if (settingKeys.Any())
                {
                    foreach (var settingKey in settingKeys)
                    {
                        builder.HasData(new Setting()
                        {
                            Id = Guid.NewGuid(),
                            Type = settingType,
                            Key = settingKey,
                            Status = StatusEnum.Active,
                        });
                    }
                }
            }
        }
    }
}
