namespace STM.Services.ScheduleJob
{
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Quartz;
    using STM.DataTranferObjects.Email;
    using STM.Repositories;
    using STM.Services.IServices;

    public class EventNotificationJob : IJob
    {
        private static IServiceScopeFactory _scopeFactory;

        public static void SetScopeFactory(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            using var scope = _scopeFactory.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var jobData = context.JobDetail.JobDataMap;

            var emailInfoAsJson = jobData.GetString("EmailInfoAsJson");
            var startDate = jobData.GetString("StartDate");
            var endDate = jobData.GetString("EndDate");
            var address = jobData.GetString("EventAddress");
            var eventContent = jobData.GetString("EventContent");

            var emailInfo = JsonConvert.DeserializeObject<EmailInfoDto>(emailInfoAsJson);

            emailInfo.Content = "<p>HOT!HOT!HOT! Sự kiện mới</p>" +
                $"Thời gian bắt đầu: <strong>{startDate}</strong> - Kết thúc: <strong>{endDate}</strong><br>" +
                $"Địa chỉ:{address}<br>" +
                $"Nội dung:<br>{eventContent}";

            emailService.SendMail(emailInfo);
        }
    }
}
