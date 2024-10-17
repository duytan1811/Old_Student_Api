namespace STM.Services.ScheduleJob
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

            var importFileAsJson = jobData.GetString("ImportFileAsJson");
            var emailInfoAsJson = jobData.GetString("EmailInfoAsJson");
            var inputFileName = jobData.GetString("InputFileName");
            var warehouseExportId = jobData.GetString("WarehouseExportId");

            var importFile = JsonConvert.DeserializeObject<byte[]>(importFileAsJson);
            var emailInfo = JsonConvert.DeserializeObject<EmailInfoDto>(emailInfoAsJson);
            unitOfWork.CurrentUserEntityId = emailInfo.CurrentUserId;

            emailInfo.File = result.ResultFile;
            emailInfo.HasAttachment = result.FailedRecordQty != 0;
            emailInfo.Content = await templateEmailService.GenerateEmailResultContent(emailInfo.ResultTemplatePath, result);

            emailService.SendMail(emailInfo);
        }
    }
}
