using System.Linq;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Configuration.Redis
{
    public class RedisConfigurationProvider : ConfigurationProvider
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisConfigurationProvider(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public override void Load()
        {
            var db = _redis.GetDatabase();
            var configEntries = db.HashScan(new RedisKey("config"));
            Data = configEntries.ToDictionary(entry => entry.Name.ToString(), entry => entry.Value.ToString());
        }
    }
}
