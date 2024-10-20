﻿namespace STM.Services.ScheduleJob
{
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json;
    using Quartz;
    using STM.DataTranferObjects.Email;
    using STM.Repositories;
    using STM.Services.IServices;

    public class JobNotificationJob : IJob
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

            var emailInfo = JsonConvert.DeserializeObject<EmailInfoDto>(emailInfoAsJson);

            emailInfo.Content = "<p>Đã thêm mới một việc làm</p>" +
                "Hãy đăng nhập hệ thống để xem chi tiết";

            emailService.SendMail(emailInfo);
        }
    }
}
