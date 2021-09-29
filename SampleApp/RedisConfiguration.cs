using System;

namespace SampleApp
{
    public class RedisConfiguration
    {
        public string Endpoint { get; set; }
        public TimeSpan RefreshInterval { get; set; }
    }
}
