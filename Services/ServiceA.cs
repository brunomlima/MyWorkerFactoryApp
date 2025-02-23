using MyWorkerFactoryApp.Services;

namespace MyWorkerFactoryApp.Services
{
    public class ServiceA : IService
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing Service A");
            await Task.Delay(1000);
        }
    }
}