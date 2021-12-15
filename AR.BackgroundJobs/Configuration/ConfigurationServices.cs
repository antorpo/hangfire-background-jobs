using AR.BackgroundJobs.Jobs;
using AR.BackgroundJobs.Jobs.Config;
using AR.BackgroundJobs.Jobs.Interfaces;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace AR.BackgroundJobs.Configuration
{
    public static class ConfigurationServices
    {
        /// <summary>
        /// AddServices
        /// </summary>
        /// <param name="services"></param>
        /// <param name="hangFireConn"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services, string hangFireConn)
        {
            #region HangFire
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSerilogLogProvider()
                .UseSqlServerStorage(hangFireConn, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true,
                    SchemaName = "AR"
                }));

            services.AddHangfireServer();
            #endregion HangFire

            #region Jobs
            services.AddSingleton<IRecurringJobScheduler, RecurringJobScheduler>();

            services.AddTransient<TestJob>();
            services.AddTransient<TestJob2>();
            #endregion Jobs

            return services;
        }

    }
}
