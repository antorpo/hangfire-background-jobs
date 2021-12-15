using AR.BackgroundJobs.Jobs.Config;
using AR.BackgroundJobs.Jobs.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AR.BackgroundJobs.Jobs
{
    /// <summary>
    /// TestJob
    /// </summary>
    public class TestJob : IJob
    {
        private readonly ILogger<TestJob> _logger;

        public TestJob(ILogger<TestJob> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="cronJobEntity"></param>
        /// <returns></returns>
        public Task Execute(CronJobEntity cronJobEntity)
        {
            _logger.LogTrace("{jobName} running at {time}", GetType().Name, DateTimeOffset.Now);
            _logger.LogInformation("Hola Mundo TestJob!");
            return Task.CompletedTask;
        }
    }
}
