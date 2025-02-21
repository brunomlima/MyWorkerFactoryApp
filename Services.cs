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