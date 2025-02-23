using MyWorkerFactoryApp.Services;

namespace MyWorkerFactoryApp.Services
{
    public class ServiceB : IService
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing Service B");
            await Task.Delay(1000);
        }
    }
}