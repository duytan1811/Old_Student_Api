namespace STM.Services.IServices
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Quartz;

    public interface ISchedulingService
    {
        Task<bool> ScheduleJob<T>(string id, DateTime triggerTime, Dictionary<string, string> jobData = null)
            where T : IJob;

        Task<bool> ScheduleJobWithCron<T>(string id, string cronExpression)
            where T : IJob;
    }
}
