namespace STM.Services.ScheduleJob
{
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Quartz;
    using STM.DataTranferObjects.Email;
    using STM.Repositories;
    using STM.Services.IServices;

    public class EventRegisterNotificationJob : IJob
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
            var eventName = jobData.GetString("EventName");

            var emailInfo = JsonConvert.DeserializeObject<EmailInfoDto>(emailInfoAsJson);

            emailInfo.Content = $"<p>Bạn đã đăn ký tham gia sự kiện {eventName} thành công</p>" +
                "Xin vui lòng chú ý thời gian diễn ra sự kiện để không bị bỏ lỡ.";

            emailService.SendMail(emailInfo);
        }
    }
}
