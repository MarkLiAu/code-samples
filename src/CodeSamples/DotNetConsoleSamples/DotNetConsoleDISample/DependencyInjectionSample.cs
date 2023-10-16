using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConsoleDISample
{
    public class DependencyInjectionSample
    {
        public static void RunSamples()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ISampleService, SampleService>()
                .BuildServiceProvider();

            var sampleService = serviceProvider.GetRequiredService<ISampleService>();
            sampleService.DoSampleWork("Hellp from DependencyInjectionSample");
        }
    }

    public interface ISampleService
    {
        void DoSampleWork(string message);
    }

    public class SampleService : ISampleService
    {
        public void DoSampleWork(string message)
        {
            Console.WriteLine(message);
        }
    }
}
