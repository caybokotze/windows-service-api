using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace WindowsServiceAPI
{
    public class Worker : BackgroundService
    {
        private readonly DoStuff _doStuff;

        public Worker(DoStuff doStuff)
        {
            _doStuff = doStuff;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Logging here and there and everywhere...");
                _doStuff.Print();
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}