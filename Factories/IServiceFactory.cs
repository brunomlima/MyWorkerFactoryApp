namespace MyWorkerFactoryApp;

public interface IServiceFactory
{
    IService CreateService(string serviceType);
}