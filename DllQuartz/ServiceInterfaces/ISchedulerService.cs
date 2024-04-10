using Quartz;
using System.Collections.Specialized;

namespace DllQuartz.ServiceInterfaces
{
    public interface ISchedulerService
    {
        Task<IScheduler> InitializeScheduler(NameValueCollection properties);

        Task ScheduleJob(Type jobType, string cronExpression, string jobIdentity, string groupIdentity);

        Task<bool> CheckJobExists(JobKey jobKey);

        Task<bool> DeleteJob(JobKey jobKey);

        IScheduler GetScheduler();
    }
}