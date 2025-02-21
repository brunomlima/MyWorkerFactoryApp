using MyWorkerFactoryApp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyWorkerFactoryApp
{
    public class Worker : BackgroundService
    {
        /// <summary>
        /// A factory interface for creating service instances.
        /// </summary>
        private readonly IServiceFactory _serviceFactory;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceFactory serviceFactory, ILogger<Worker> logger)
        {
            _serviceFactory = serviceFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

            var services = new List<IService>
            {
                _serviceFactory.CreateService("ServiceA"),
                _serviceFactory.CreateService("ServiceB"),
                _serviceFactory.CreateService("ServiceC")
            };

            while (!stoppingToken.IsCancellationRequested)
            {
                foreach (var service in services)
                {
                    await service.ExecuteAsync();
                }
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}