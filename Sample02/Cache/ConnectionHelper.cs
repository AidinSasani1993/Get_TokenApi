using StackExchange.Redis;

namespace Sample02.Cache
{
    public class ConnectionHelper
    {
        static ConnectionHelper()
        {
            ConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                //return ConnectionMultiplexer.Connect(ConfigurationManager.AppSetting["RedisURL"]);
                return ConnectionMultiplexer.Connect("mycache.redis.cache.windows.net,abortConnect=false,ssl=true,ConnectTimeout=10000");
            });
        }
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
