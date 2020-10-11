namespace Alore.Config
{
    using Alore.API.Config;

    internal class ConfigController : IConfigController
    {
        private readonly ConfigRepository _configRepository;

        public ConfigController(ConfigRepository configRepository)
        {
            _configRepository = configRepository;
            _configRepository.CacheConfig("database", new DatabaseConfig());
        }

        public TConfig Get<TConfig>(string name)
            where TConfig : AbstractConfig
        {
            if (_configRepository.TryGetConfig<TConfig>(name, out AbstractConfig config))
            {
                return (TConfig)config;
            }

            return null;
        }
    }
}