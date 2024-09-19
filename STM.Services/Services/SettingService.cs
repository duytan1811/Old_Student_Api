namespace STM.Services.Services
{
    using STM.Common.Constants;
    using STM.DataTranferObjects.Settings;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<SettingDto> GetSettingByKey(string key)
        {
            var query = await this._unitOfWork.GetRepositoryReadOnlyAsync<Setting>().QueryAll();

            var setting = query.Where(x => x.Key == key).FirstOrDefault();

            if (setting == null)
            {
                return null;
            }

            return new SettingDto()
            {
                Key = setting.Key,
                Value = setting.Value,
                Type = setting.Type,
            };
        }

        public async Task<List<SettingDto>> GetSettingsByType(string type)
        {
            var query = await this._unitOfWork.GetRepositoryReadOnlyAsync<Setting>().QueryAll();
            query = query.Where(x => x.Type == type);

            return query.Select(x => new SettingDto()
            {
                Key = x.Key,
                Value = x.Value,
                Type = x.Type,
            }).ToList();
        }

        public async Task<string> Update(List<SettingSaveDto> settings)
        {
            var settingRep = this._unitOfWork.GetRepositoryAsync<Setting>();
            var settingKeys = settings.Select(x => x.Key).ToList();

            var dataSettings = (await settingRep.QueryCondition(x => settingKeys.Contains(x.Key))).ToList();

            foreach (var setting in settings)
            {
                var objSetting = dataSettings.FirstOrDefault(x => x.Key == setting.Key);
                if (objSetting == null)
                {
                    await settingRep.Add(new Setting
                    {
                        Key = setting.Key,
                        Value = setting.Value,
                        Type = setting.Type,
                    });
                }
                else
                {
                    objSetting.Value = setting.Value;

                    await settingRep.Update(objSetting);
                }
            }

            await this._unitOfWork.SaveChangesAsync();
            return Messages.UpdateSuccess;
        }
    }
}
