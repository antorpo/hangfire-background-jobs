using AR.BackgroundJobs.Jobs;
using AR.BackgroundJobs.Jobs.Config;
using AR.BackgroundJobs.Jobs.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AR.BackgroundJobs.Configuration
{
    /// <summary>
    /// ConfigurationJobs
    /// </summary>
    public static class ConfigurationJobs
    {

        /// <summary>
        /// AddJobs
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceProvider AddJobs(this IServiceProvider serviceProvider, IConfiguration configuration)
        {
            List<CronJobEntity> cronJobs = configuration.GetSection("Jobs").Get<List<CronJobEntity>>();
            var scheduler = serviceProvider.GetRequiredService<IRecurringJobScheduler>() as RecurringJobScheduler;

            // Jobs
            CronJobEntity testJob = cronJobs.Find(x => x.Name.Equals("TestJob"));
            CronJobEntity testJob2 = cronJobs.Find(x => x.Name.Equals("TestJob2"));

            scheduler.Register<TestJob>(testJob);
            scheduler.Register<TestJob2>(testJob2);
            return serviceProvider;
        }

    }
}
