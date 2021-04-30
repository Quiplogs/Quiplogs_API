namespace Api.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }

    public class RedisSettings
    {
        public bool AllowAdmin { get; set; }
        public bool Ssl { get; set; }
        public int ConnectTimeout { get; set; }
        public int ConnectRetry { get; set; }
        public int Database { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Password { get; set; }
    }
}
