namespace STM.Services.IServices
{
    using STM.DataTranferObjects.Statistics;

    public interface IStatisticsService
    {
        Task<List<EventByMonthDto>> GetEventByMonths();

        Task<List<MemberByMonthDto>> GetMemberByMonths();

        Task<List<NewsByMonthDto>> GetNewsByMonths();

        Task<List<StudentByMajorDto>> GetStudentByMajor();

        Task<List<StudentByYearDto>> GetStudentByYear();
    }
}
