using MyWorkerFactoryApp.Services;
namespace MyWorkerFactoryApp.Factories;

public interface IServiceFactory
{
    IService CreateService(string serviceType);
}