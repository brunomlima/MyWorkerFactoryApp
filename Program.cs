using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Serilog;
using MyWorkerFactoryApp.Configurations;

namespace MyWorkerFactoryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ✅ Criar Host Builder para capturar o ambiente
            var hostBuilder = Host.CreateDefaultBuilder(args).Build();
            var env = hostBuilder.Services.GetRequiredService<IHostEnvironment>();

            // ✅ Configurar carregamento de arquivos baseados no ambiente (Development, Production, etc.)
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true) // Ambiente dinâmico
                .AddEnvironmentVariables() // Permite sobrescrever configurações com variáveis de ambiente
                .Build();

            // ✅ Configurar Serilog para logging estruturado
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config) // Agora lê as configurações corretamente do ambiente
                .WriteTo.Console()
                .WriteTo.File($"logs/{env.EnvironmentName}-log-.txt", rollingInterval: RollingInterval.Day) // Logs diferentes por ambiente
                .CreateLogger();

            try
            {
                Log.Information("🚀 Starting Worker Service ({Environment})", env.EnvironmentName);

                var host = CreateHostBuilder(args, config).Build();

                // ✅ Obter serviços e registrar mensagem de inicialização
                using (var scope = host.Services.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

                    // ✅ Chamar o StartupLogger para exibir informações detalhadas do Worker
                    StartupLogger.LogStartupMessage(config, env, logger);
                }

                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "❌ Worker Service terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration config) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // Configuração do Serilog
                .ConfigureServices((hostContext, services) =>
                {
                    // ✅ Configurar DI para WorkerConfig
                    services.Configure<WorkerConfig>(config.GetSection("WorkerConfig"));

                    // ✅ Registrar ServiceFactory e Worker
                    services.AddSingleton<IServiceFactory, ServiceFactory>();
                    services.AddHostedService<Worker>();
                });
    }
}
