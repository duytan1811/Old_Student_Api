namespace STM.Services.Services
{
    using Microsoft.EntityFrameworkCore;
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

        public async Task<List<MemberByMonthDto>> GetMemberByMonths()
        {
            var queryNews = await this._unitOfWork.GetRepositoryReadOnlyAsync<User>().QueryAll();

            var userByYear = queryNews.Where(x => x.CreatedAt.Year == DateTime.Now.Year && !x.IsAdmin).ToList();

            var result = new List<MemberByMonthDto>();

            for (int i = 1; i <= 12; i++)
            {
                var countMemberByMonth = userByYear.Where(x => x.CreatedAt.Month == i).Count();
                result.Add(new MemberByMonthDto
                {
                    Month = i,
                    CountMember = countMemberByMonth,
                });
            }

            return result;
        }

        public async Task<List<NewsByMonthDto>> GetNewsByMonths()
        {
            var queryNews = await this._unitOfWork.GetRepositoryReadOnlyAsync<News>().QueryAll();

            var userByYear = queryNews.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Year == DateTime.Now.Year).ToList();

            var result = new List<NewsByMonthDto>();

            for (int i = 1; i <= 12; i++)
            {
                var countMemberByMonth = userByYear.Where(x => x.CreatedAt.HasValue && x.CreatedAt.Value.Month == i).Count();
                result.Add(new NewsByMonthDto
                {
                    Month = i,
                    CountNews = countMemberByMonth,
                });
            }

            return result;
        }

        public async Task<List<StudentByMajorDto>> GetStudentByMajor()
        {
            var queryMajor = await this._unitOfWork.GetRepositoryReadOnlyAsync<Major>().QueryAll();
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();

            var majors = queryMajor.ToList();
            var students = queryStudent.Where(x => x.MajorId.HasValue).ToList();

            var result = new List<StudentByMajorDto>();
            foreach (var major in majors)
            {
                result.Add(new StudentByMajorDto
                {
                    MajorName = major.Name,
                    CountStudent = students.Count(x => x.MajorId == major.Id),
                });
            }

            return result;
        }

        public async Task<List<StudentByYearDto>> GetStudentByYear()
        {
            var queryStudent = await this._unitOfWork.GetRepositoryReadOnlyAsync<Student>().QueryAll();

            var result = queryStudent.Include(x => x.Major).Where(x => x.SchoolYear.HasValue)
                .GroupBy(x => x.SchoolYear).Select(x => new StudentByYearDto
                {
                    Year = x.Key.Value,
                    CountStudent = x.Count(),
                }).ToList();
            return result;
        }
    }
}
