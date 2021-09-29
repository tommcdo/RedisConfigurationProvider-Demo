using Configuration.Redis;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Hosting
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddRedis(this IConfigurationBuilder builder, string endpoint)
        {
            return builder.Add(new RedisConfigurationSource(endpoint));
        }
    }
}
