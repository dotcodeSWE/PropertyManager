using MediatR;

namespace Customer.Worker.BackgroundWorkers
{
    public class CustomerBackgroundTasks
    {
        private readonly IServiceProvider _serviceProvider;
        private const int defaultOlderThanDays = 24;

        public CustomerBackgroundTasks(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void ConsumeCustomer(string id, int olderThanDays)
        {
            using var scope = _serviceProvider.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<CustomerBackgroundTasks>>();
            logger.LogInformation("Starting ConsumeCustomer {id}", id);


        }
        private void DoTask(int olderThanDays)
        {
            using var scope = _serviceProvider.CreateScope();
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<CustomerBackgroundTasks>>();
            try
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var date = DateTime.Now.AddDays(-olderThanDays);
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error testTemp: {ex.Message}", ex.ToString());
            }
        }
    }
}
