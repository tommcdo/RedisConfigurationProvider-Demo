using System;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Configuration.Redis
{
    public class RedisConfigurationSource : IConfigurationSource
    {
        private readonly string _endpoint;
        private readonly TimeSpan _refreshInterval;

        public RedisConfigurationSource(string endpoint, TimeSpan refreshInterval)
        {
            _endpoint = endpoint;
            _refreshInterval = refreshInterval;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var redis = ConnectionMultiplexer.Connect(_endpoint);
            return new RedisConfigurationProvider(redis, _refreshInterval);
        }
    }
}
