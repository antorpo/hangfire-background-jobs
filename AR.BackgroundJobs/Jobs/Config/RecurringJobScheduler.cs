using AR.BackgroundJobs.Helpers;
using AR.BackgroundJobs.Jobs.Interfaces;
using Hangfire;
using System;

namespace AR.BackgroundJobs.Jobs.Config
{
    /// <summary>
    /// RecurringJobScheduler
    /// </summary>
    public class RecurringJobScheduler : IRecurringJobScheduler
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cronJobEntity"></param>
        public void Register<T>(CronJobEntity cronJobEntity) where T : IJob
        {
            RecurringJob.RemoveIfExists(cronJobEntity.Name);
            RecurringJob.AddOrUpdate<T>(cronJobEntity.Name, job =>
                job.Execute(cronJobEntity), cronJobEntity.GenerateCron(), TimeZoneInfo.Utc);
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cronJobEntity"></param>
        public void Remove<T>(CronJobEntity cronJobEntity) where T : IJob
        {
            RecurringJob.RemoveIfExists(cronJobEntity.Name);
        }
    }
}
