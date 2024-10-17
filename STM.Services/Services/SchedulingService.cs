namespace Infomed.CSSD.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Quartz;
    using STM.Services.IServices;

    public class SchedulingService : ISchedulingService
    {
        private readonly ILogger<SchedulingService> _logger;
        private readonly ISchedulerFactory _schedulerFactory;

        public SchedulingService(
            ILogger<SchedulingService> logger,
            ISchedulerFactory schedulerFactory)
        {
            this._logger = logger;
            this._schedulerFactory = schedulerFactory;
        }

        public async Task<bool> ScheduleJobWithCron<T>(string id, string cronExpression)
            where T : IJob
        {
            try
            {
                this._logger.LogInformation($"Scheduling job {id} with cron expression ({cronExpression}): {typeof(T).Name}");

                var scheduler = await this._schedulerFactory.GetScheduler();
                var jobKey = new JobKey($"{id}.jobKey");
                var triggerKey = new TriggerKey($"{id}.triggerKey");

                var jobDetailBuilder = JobBuilder.Create<T>()
                    .WithIdentity(jobKey);

                var jobDetail = jobDetailBuilder.Build();

                var trigger = TriggerBuilder.Create()
                    .ForJob(jobDetail)
                    .WithIdentity(triggerKey)
                    .WithCronSchedule(cronExpression)
                    .StartNow()
                    .Build();

                await scheduler.ScheduleJob(jobDetail, trigger);
                await scheduler.Start();

                this._logger.LogInformation($"Scheduling complete for: {id}");

                return true;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Schedule job error: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Schedule for background job.
        /// </summary>
        /// <typeparam name="T">Job type, implements IJob.</typeparam>
        /// <param name="id">Unique id.</param>
        /// <param name="triggerTime">Trigger time.</param>
        /// <param name="jobData">Job data.</param>
        /// <returns>True/False.</returns>
        public async Task<bool> ScheduleJob<T>(string id, DateTime triggerTime, Dictionary<string, string> jobData = null)
            where T : IJob
        {
            try
            {
                this._logger.LogInformation($"Scheduling job {id} at {triggerTime}: {typeof(T).Name}");

                var scheduler = await this._schedulerFactory.GetScheduler();
                var jobKey = new JobKey($"{id}.jobKey");
                var triggerKey = new TriggerKey($"{id}.triggerKey");

                if (await scheduler.CheckExists(jobKey))
                {
                    this._logger.LogInformation($"Delete running job: {jobKey}");
                    await scheduler.DeleteJob(jobKey);
                }

                var jobDetailBuilder = JobBuilder.Create<T>()
                    .WithIdentity(jobKey);

                if (jobData != null && jobData.Any())
                {
                    foreach (var (key, value) in jobData)
                    {
                        jobDetailBuilder = jobDetailBuilder.UsingJobData(key, value);
                    }
                }

                var jobDetail = jobDetailBuilder.Build();

                var trigger = TriggerBuilder.Create()
                    .ForJob(jobDetail)
                    .WithIdentity(triggerKey)
                    .StartAt(triggerTime)
                    .Build();

                await scheduler.ScheduleJob(jobDetail, trigger);
                await scheduler.Start();

                this._logger.LogInformation($"Scheduling complete for: {id}");

                return true;
            }
            catch (Exception ex)
            {
                this._logger.LogError($"Schedule job error: {ex}");
                return false;
            }
        }
    }
}
