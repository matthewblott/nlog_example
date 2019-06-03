using System;
using AutoMapper;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nlog_example.services;

namespace nlog_example.web
{
  public class Startup
  {
    public Startup()
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");
      
      builder.AddUserSecrets<Startup>();
      
      Configuration = builder.Build();
      
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper();
      services.AddRouting(x => x.LowercaseUrls = true);
      services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
        .AddRazorRuntimeCompilation();
      
      services.AddScoped<IProductService, ProductService>();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddScoped<LogFilter>();
      
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
      
    }
    
  }
  
}