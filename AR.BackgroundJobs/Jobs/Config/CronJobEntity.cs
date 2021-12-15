namespace AR.BackgroundJobs.Jobs.Config
{
    /// <summary>
    /// CronEntity
    /// </summary>
    public class CronJobEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// CRON_JOB_MONTH
        /// </summary>
        public string CRON_JOB_MONTH { get; set; }

        /// <summary>
        /// CRON_JOB_DAY
        /// </summary>
        public string CRON_JOB_DAY { get; set; }

        /// <summary>
        /// CRON_JOB_HOUR
        /// </summary>
        public string CRON_JOB_HOUR { get; set; }

        /// <summary>
        /// CRON_JOB_MINUTES
        /// </summary>
        public string CRON_JOB_MINUTES { get; set; }
    }
}
