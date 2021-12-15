using AR.BackgroundJobs.Jobs.Config;
using System;

namespace AR.BackgroundJobs.Helpers
{
    /// <summary>
    /// CronHelper
    /// </summary>
    public static class CronHelper
    {
        /// <summary>
        /// Crons the expression builder.
        /// </summary>
        /// <param name="minute">The minute.</param>
        /// <param name="hour">The hour.</param>
        /// <param name="day">The day.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public static string cronExpressionBuilder(int minute = 0, int hour = 0, int day = 0, int month = 0)
        {
            string minute_cron = hour == 0 ? $"*/{minute}" : $"{minute}";
            string hour_cron = hour == 0 ? "*" : $"{hour}";
            string day_cron = day == 0 ? "*" : $"{(int)DateTime.Now.DayOfWeek}/{day}";
            string month_cron = month == 0 ? "*" : $"{DateTime.Now.Month}/{month}";
            return $"{minute_cron} {hour_cron} * {month_cron} {day_cron}";
        }

        /// <summary>
        /// GenerateCron
        /// </summary>
        /// <param name="cronEntity"></param>
        /// <returns></returns>
        public static string GenerateCron(this CronJobEntity cronEntity)
        {
            int minute = int.Parse(cronEntity.CRON_JOB_MINUTES);
            int hour = int.Parse(cronEntity.CRON_JOB_HOUR);
            int day = int.Parse(cronEntity.CRON_JOB_DAY);
            int month = int.Parse(cronEntity.CRON_JOB_MONTH);

            return cronExpressionBuilder(minute, hour, day, month);
        }
    }
}
