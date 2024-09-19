namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Settings;

    public interface ISettingService
    {
        Task<SettingDto> GetSettingByKey(string key);

        Task<List<SettingDto>> GetSettingsByType(string type);

        Task<string> Update(List<SettingSaveDto> settings);
    }
}
