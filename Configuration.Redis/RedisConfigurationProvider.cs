using System;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Configuration.Redis
{
    public class RedisConfigurationProvider : ConfigurationProvider
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly Timer _configurationReloadTimer;

        public RedisConfigurationProvider(IConnectionMultiplexer redis, TimeSpan refreshInterval)
        {
            _redis = redis;
            _configurationReloadTimer = new Timer(_ => Load(), null, refreshInterval, refreshInterval);
        }

        public override void Load()
        {
            var db = _redis.GetDatabase();
            var configEntries = db.HashScan(new RedisKey("config"));
            Data = configEntries.ToDictionary(entry => entry.Name.ToString(), entry => entry.Value.ToString());
            OnReload();
        }
    }
}
