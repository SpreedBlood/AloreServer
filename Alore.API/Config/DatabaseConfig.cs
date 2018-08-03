namespace Alore.API.Config
{
    public class DatabaseConfig : AbstractConfig
    {
        [ConfigField("port")]
        public string Port { get; set; }

        [ConfigField("host")]
        public string Host { get; set; }

        [ConfigField("user")]
        public string User { get; set; }

        [ConfigField("password")]
        public string Password { get; set; }

        [ConfigField("database")]
        public string Database { get; set; }
    }
}
