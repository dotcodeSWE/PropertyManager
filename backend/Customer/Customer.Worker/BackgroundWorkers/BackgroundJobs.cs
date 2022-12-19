using Hangfire;
using Microsoft.Extensions.Options;
using Customer.Worker.Settings;

namespace Customer.Worker.BackgroundWorkers
{
    public static class BackgroundJobs
    {
        public static void Init(IServiceProvider services)
        {
            InitCustomer(services);
        }

        private static void InitCustomer(IServiceProvider services)
        {
            var settings = services.GetRequiredService<IOptionsMonitor<TaskSettings>>();
            var task = services.GetRequiredService<CustomerBackgroundTasks>();
            RecurringJob.AddOrUpdate(() => task.ConsumeCustomer(Guid.NewGuid().ToString(), settings.CurrentValue.OlderThanDays), settings.CurrentValue.ExecuteEvery);
        }
    }
}
