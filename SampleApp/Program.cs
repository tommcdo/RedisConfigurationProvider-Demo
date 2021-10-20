using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureAppConfiguration(configuration =>
                    {
                        var tempConfig = configuration.Build();
                        var redisConfiguration = tempConfig.GetSection("RedisConfiguration").Get<RedisConfiguration>();
                        configuration.AddRedis(redisConfiguration.Endpoint, redisConfiguration.RefreshInterval);
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
