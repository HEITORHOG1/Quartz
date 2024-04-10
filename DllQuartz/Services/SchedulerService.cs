using DllQuartz.ServiceInterfaces;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace DllQuartz.Services
{
    public class SchedulerService : ISchedulerService
    {
        private IScheduler _scheduler;

        public async Task<bool> CheckJobExists(JobKey jobKey)
        {
            return await _scheduler.CheckExists(jobKey);
        }

        public async Task<bool> DeleteJob(JobKey jobKey)
        {
            return await _scheduler.DeleteJob(jobKey);
        }

        public IScheduler GetScheduler()
        {
            return _scheduler;
        }

        public async Task<IScheduler> InitializeScheduler(NameValueCollection properties)
        {
            if (_scheduler != null && !_scheduler.IsShutdown)
            {
                return _scheduler;
            }

            StdSchedulerFactory factory = new StdSchedulerFactory(properties);
            _scheduler = await factory.GetScheduler();
            await _scheduler.Start();
            return _scheduler;
        }

        public async Task ScheduleJob(Type jobType, string cronExpression, string jobIdentity, string groupIdentity)
        {
            var jobDetail = JobBuilder.Create(jobType)
                .WithIdentity(jobIdentity, groupIdentity)
                .Build();

            var trigger = TriggerBuilder.Create()
                .WithIdentity($"{jobIdentity}Trigger", groupIdentity)
                .WithCronSchedule(cronExpression)
                .Build();

            await _scheduler.ScheduleJob(jobDetail, trigger);
        }

        // Implementação dos outros métodos de acordo com a interface...
    }
}