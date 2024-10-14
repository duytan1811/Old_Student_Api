namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Statistics;

    public interface IStatisticsService
    {
        Task<List<EventByMonthDto>> GetEventByMonths();
    }
}
