using AR.BackgroundJobs.Jobs.Config;
using AR.BackgroundJobs.Jobs.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AR.BackgroundJobs.Jobs
{
    /// <summary>
    /// TestJob2
    /// </summary>
    public class TestJob2 : IJob
    {
        private readonly ILogger<TestJob2> _logger;

        public TestJob2(ILogger<TestJob2> logger)
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
            _logger.LogInformation("Hola Mundo TestJob2!");
            return Task.CompletedTask;
        }
    }
}
