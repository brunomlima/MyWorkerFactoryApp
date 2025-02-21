# Passo a Passo para Criar o Projeto MyWorkerFactoryApp

Este guia descreve como criar um Worker Service robusto em .NET seguindo Clean Code e utilizando Factory Pattern.

## 1️⃣ Criar o Projeto Worker Service

Execute o seguinte comando no terminal para criar um novo projeto:
```bash
dotnet new worker -n MyWorkerFactoryApp
cd MyWorkerFactoryApp
```

## 2️⃣ Adicionar Dependências Necessárias
Execute os comandos abaixo para adicionar pacotes essenciais:
```bash
dotnet add package Microsoft.Extensions.Hosting
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.File
```

## 3️⃣ Configurar o Worker Service

Edite `Program.cs` para adicionar logging com Serilog e configurar a injeção de dependências:
```csharp
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MyWorkerFactoryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            try
            {
                Log.Information("Starting Worker Service");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Worker Service terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IServiceFactory, ServiceFactory>();
                    services.AddHostedService<Worker>();
                });
    }
}
```

## 4️⃣ Criar o Worker para Gerenciar Serviços

Crie um arquivo `Worker.cs` e implemente a lógica para rodar os serviços:
```csharp
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
```

## 5️⃣ Criar os Serviços

Crie um arquivo `Services.cs` e implemente os serviços:
```csharp
namespace MyWorkerFactoryApp
{
    public interface IService
    {
        Task ExecuteAsync();
    }

    public class ServiceA : IService
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing Service A");
            await Task.Delay(1000);
        }
    }

    public class ServiceB : IService
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing Service B");
            await Task.Delay(1000);
        }
    }

    public class ServiceC : IService
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing Service C");
            await Task.Delay(1000);
        }
    }
}
```

## 6️⃣ Criar o Factory Pattern para Gerenciar Serviços

Crie um arquivo `ServiceFactory.cs` e implemente o Factory Pattern:
```csharp
namespace MyWorkerFactoryApp
{
    public interface IServiceFactory
    {
        IService CreateService(string serviceType);
    }

    public class ServiceFactory : IServiceFactory
    {
        public IService CreateService(string serviceType) => serviceType switch
        {
            "ServiceA" => new ServiceA(),
            "ServiceB" => new ServiceB(),
            "ServiceC" => new ServiceC(),
            _ => throw new ArgumentException("Invalid service type", nameof(serviceType))
        };
    }
}
```

## 7️⃣ Executar o Projeto

Para testar a implementação, execute:
```bash
dotnet run
```

Isso garantirá que os três serviços rodem periodicamente dentro do Worker.

---

O Worker Service agora está totalmente funcional seguindo os princípios do **Clean Code** e **Factory Pattern**. 🚀
