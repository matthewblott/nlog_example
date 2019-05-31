﻿using Microsoft.Extensions.DependencyInjection;

namespace nlog_example
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var services = Startup.ConfigureServices();
      var serviceProvider = services.BuildServiceProvider();

      Startup.ConfigureLogging(serviceProvider);

      var app = serviceProvider.GetService<IApplication>();

      app.Run();

      NLog.LogManager.Shutdown(); 

    }

  }

}