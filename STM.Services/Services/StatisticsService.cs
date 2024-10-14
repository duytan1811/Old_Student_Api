namespace STM.Services.Services
{
    using STM.DataTranferObjects.Statistics;
    using STM.Entities.Models;
    using STM.Repositories;
    using STM.Services.IServices;

    public class StatisticsService : IStatisticsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<EventByMonthDto>> GetEventByMonths()
        {
            var queryEvent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Event>().QueryAll();

            var eventByYear = queryEvent.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Year == DateTime.Now.Year).ToList();

            var result = new List<EventByMonthDto>();

            for (int i = 1; i <= 12; i++)
            {
                var countEventByMonth = eventByYear.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Month == i).Count();
                result.Add(new EventByMonthDto
                {
                    Month = i,
                    CountEvent = countEventByMonth,
                });
            }

            return result;
        }
    }
}
