using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyWorkerFactoryApp.Configurations;
using System;
using System.Linq;

public static class StartupLogger
{
    public static void LogStartupMessage(IConfiguration configuration, IHostEnvironment hostingEnvironment, ILogger logger)
    {
        // ✅ Obter a configuração do Worker
        var workerConfig = configuration.GetSection("WorkerConfig").Get<WorkerConfig>() ?? new WorkerConfig();

        // ✅ Mensagem de inicialização
        logger.LogInformation("🚀 MyWorkerFactoryApp Iniciado!");
        logger.LogInformation("🌍 Ambiente: {EnvironmentName}", hostingEnvironment.EnvironmentName);

        // ✅ Contagem de serviços ativos/inativos
        int ativos = workerConfig.Servicos.Count(s => s.Ativo);
        int inativos = workerConfig.Servicos.Count(s => !s.Ativo);

        logger.LogInformation("📢 Total de serviços configurados: {Total} | Ativos: {Ativos} ✅ | Inativos: {Inativos} ❌",
            workerConfig.Servicos.Count, ativos, inativos);

        // ✅ Listar serviços com horários de execução
        foreach (var servico in workerConfig.Servicos)
        {
            if (servico.Horario != null)
            {
                logger.LogInformation("➡️ {ServicoNome}: {Status} | ⏰ {HoraInicio} - {HoraTermino} | ⏳ Delay: {TempoEsperaMs}ms",
                    servico.Nome, servico.Ativo ? "Ativo ✅" : "Desativado ❌",
                    servico.Horario.Inicio, servico.Horario.Fim, servico.TempoEsperaMs);
            }
            else
            {
                logger.LogInformation("➡️ {ServicoNome}: {Status} | ⏳ Delay: {TempoEsperaMs}ms",
                    servico.Nome, servico.Ativo ? "Ativo ✅" : "Desativado ❌",
                    servico.TempoEsperaMs);
            }
        }

        logger.LogInformation("📅 Monitorando horários de execução...");
    }
}
