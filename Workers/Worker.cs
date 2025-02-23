using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyWorkerFactoryApp.Configurations;
using MyWorkerFactoryApp.Factories;
using MyWorkerFactoryApp.Services;


namespace MyWorkerFactoryApp.Workers
{
    public class Worker : BackgroundService
    {
        private readonly IServiceFactory _serviceFactory;
        private readonly ILogger<Worker> _logger;
        private readonly WorkerConfig _config;

        public Worker(IServiceFactory serviceFactory, ILogger<Worker> logger, IOptions<WorkerConfig> config)
        {
            _serviceFactory = serviceFactory;
            _logger = logger;
            _config = config.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker iniciado em: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                var agora = DateTime.Now.TimeOfDay;
                var servicosAtivos = _config.Servicos
                    .Where(s => s.Ativo && s.Horario != null && s.Horario.EstaDentroDoHorario())
                    .ToList();

                if (!servicosAtivos.Any())
                {
                    _logger.LogInformation("Nenhum serviço ativo no horário atual: {time}", agora);
                    await Task.Delay(5000, stoppingToken);
                    continue;
                }

                foreach (var servicoConfig in servicosAtivos)
                {
                    var service = _serviceFactory.CreateService(servicoConfig.Nome);
                    if (service != null)
                    {
                        _logger.LogInformation("🚀 Executando serviço: {Nome} às {Time}", servicoConfig.Nome, DateTimeOffset.Now);
                        await service.ExecuteAsync();
                        _logger.LogInformation("⏳ Serviço {Nome} finalizado. Próxima execução em {TempoEsperaMs}ms...", servicoConfig.Nome, servicoConfig.TempoEsperaMs);
                        await Task.Delay(servicoConfig.TempoEsperaMs, stoppingToken);
                    }
                    else
                    {
                        _logger.LogWarning("Serviço não encontrado: {Nome}", servicoConfig.Nome);
                    }
                }
            }
        }
    }
}
