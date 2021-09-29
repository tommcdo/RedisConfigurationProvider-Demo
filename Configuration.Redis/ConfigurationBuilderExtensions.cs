using System;
using Configuration.Redis;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Hosting
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddRedis(this IConfigurationBuilder builder, string endpoint, TimeSpan refreshInterval)
        {
            return builder.Add(new RedisConfigurationSource(endpoint, refreshInterval));
        }
    }
}
