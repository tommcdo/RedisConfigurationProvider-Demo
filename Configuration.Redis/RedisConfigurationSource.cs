using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Configuration.Redis
{
    public class RedisConfigurationSource : IConfigurationSource
    {
        private readonly string _endpoint;

        public RedisConfigurationSource(string endpoint)
        {
            _endpoint = endpoint;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var redis = ConnectionMultiplexer.Connect(_endpoint);
            return new RedisConfigurationProvider(redis);
        }
    }
}
