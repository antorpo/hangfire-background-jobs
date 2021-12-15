using AR.BackgroundJobs.Jobs.Config;

namespace AR.BackgroundJobs.Jobs.Interfaces
{
    /// <summary>
    /// IRecurringJobScheduler
    /// </summary>
    public interface IRecurringJobScheduler
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void Register<T>(CronJobEntity cronJobEntity) where T : IJob;

        /// <summary>
        /// Remove
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>(CronJobEntity cronJobEntity) where T : IJob;
    }
}
