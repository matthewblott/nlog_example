using System;
using nlog_example.services;
using nlog_example.web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace nlog_example.console
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var services = new ServiceCollection();
      var startup = new Startup();
      
      startup.ConfigureServices(services);

      var serviceProvider = services.BuildServiceProvider();
      var service = serviceProvider.GetService<IProductService>();
      var product = service.GetById(1);

      Console.WriteLine(product?.Name);

    }
    
  }
  
}