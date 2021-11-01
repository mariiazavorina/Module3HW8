using Microsoft.Extensions.DependencyInjection;
using Module3HW8.Processors;
using Module3HW8.Processors.Abstractions;

namespace Module3HW8
{
    public class ApplicationSet
    {
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
                            .AddSingleton<IFileProcessor, FileProcessor>()
                            .AddTransient<IDataProcessor, DataProcessor>()
                            .AddTransient<Starter>()
                            .BuildServiceProvider();

            var appStarter = serviceProvider.GetService<Starter>();
            appStarter.Run();
        }
    }
}
