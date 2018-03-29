using Alore.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Alore
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using API;
    using API.Sql.Test;
    using Network;

    public static class Program
    {
        private static Listener _listener;

        public static async Task Main()
        {
            //await TestAloreSql();

            // TODO: construct the Program class instead of having things staticly.
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole());
            
            ControllerDiHelper.ConfigureServices(serviceCollection);
            ClientPacketDiHelper.ConfigureServices(serviceCollection);
            
            serviceCollection.AddSingleton<IEventProvider, EventProvider>();

            serviceCollection.AddScoped<Listener>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _listener = serviceProvider.GetService<Listener>();
            
            await _listener.Listen(30000);

            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    await DisposeAsync();
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static async Task TestAloreSql()
        {
            SqlTest testSql = new SqlTest();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            TestModel testModel = await testSql.TestSql();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Stop();

            Console.WriteLine("Alore MySQL benchmark done!");
        }

        private static async Task DisposeAsync()
        {
            await _listener.DisposeAsync();

            Console.WriteLine("Finished!");
            Environment.Exit(0);
        }
    }
}