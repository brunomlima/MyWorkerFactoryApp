using MyWorkerFactoryApp.Services;
namespace MyWorkerFactoryApp.Factories
{
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