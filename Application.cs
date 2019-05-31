using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace nlog_example
{
  public class Application : IApplication
  {
    ILogger<Application> _logger;
    MyOptions _settings;

    public Application(ILogger<Application> logger, IOptions<MyOptions> settings)
    {
      _logger = logger;
      _settings = settings.Value;
    }

    public void Run()
    {
      try
      {
        _logger.LogInformation($"This is a console application for {_settings.Name}");
      }
      catch (Exception ex)
      {
        _logger.LogError(ex.ToString());
      }

    }

  }

}