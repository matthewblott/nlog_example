using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace nlog_example
{
  public static class Startup
  {
    public static IServiceCollection ConfigureServices()
    {
      var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true).Build();

      var services = new ServiceCollection();

      services.AddSingleton<ILoggerFactory, LoggerFactory>();
      services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
      services.AddLogging((builder) => builder.SetMinimumLevel(LogLevel.Trace));
      services.AddSingleton<IConfigurationRoot>(configuration);
      services.AddOptions();
      services.Configure<MyOptions>(configuration.GetSection(nameof(MyOptions)));
      services.AddTransient<IApplication, Application>();

      return services;

    }

    public static void ConfigureLogging(IServiceProvider serviceProvider)
    {
      var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

      loggerFactory.AddNLog(new NLogProviderOptions
      {
        CaptureMessageTemplates = true,
        CaptureMessageProperties = true
      });

      NLog.LogManager.LoadConfiguration("nlog.config");

    }

  }

}