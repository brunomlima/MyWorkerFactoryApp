namespace MyWorkerFactoryApp
{
    public class ServiceC : IService
    {
        public async Task ExecuteAsync()
        {
            Console.WriteLine("Executing Service C");
            await Task.Delay(1000);
        }
    }
}