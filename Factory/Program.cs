using Microsoft.Extensions.DependencyInjection;

namespace Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<Service>();
            services.AddTransient<DomainObject>();

            var obj = services.BuildServiceProvider().GetService<DomainObject>();
            Console.WriteLine(obj);

        }
    }
}