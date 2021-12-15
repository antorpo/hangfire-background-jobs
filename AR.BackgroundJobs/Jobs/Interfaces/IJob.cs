using AR.BackgroundJobs.Jobs.Config;
using System.Threading.Tasks;

namespace AR.BackgroundJobs.Jobs.Interfaces
{
    /// <summary>
    /// IJob
    /// </summary>
    public interface IJob
    {
        /// <summary>
        /// Execute
        /// </summary>
        /// <returns></returns>
        Task Execute(CronJobEntity cronJobEntity);
    }
}
