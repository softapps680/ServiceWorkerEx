using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        
        private readonly ILogger<Worker> _logger;
       
        private readonly Random _random = new Random();

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            
            _logger.LogInformation("Service stopped");
            return base.StopAsync(cancellationToken);
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
           
           
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int num = _random.Next();
                DateTime now = DateTime.Now;

                 if (num != 0)
                {
                    _logger.LogInformation("Worker running at: {now}",now.ToString("yyyy-MM-dd kl HH:mm:ss"));
                    _logger.LogInformation("Number: {num}", num);
                }
                else
                {
                    _logger.LogError("Noll");
                }
               
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
