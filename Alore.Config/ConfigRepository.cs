namespace Alore.Config
{
    using Alore.API.Config;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    internal class ConfigRepository
    {
        private readonly IDictionary<string, AbstractConfig> _configurations;

        public ConfigRepository()
        {
            _configurations = new Dictionary<string, AbstractConfig>();
        }

        internal void CacheConfig(string configName, AbstractConfig config)
        {
            string[] lines = ReadFile(configName);
            config.SetPropertyValues(lines);
            _configurations.Add(configName, config);
        }

        internal bool TryGetConfig<TConfig>(string configName, out AbstractConfig config) =>
            _configurations.TryGetValue(configName, out config);

        private string[] ReadFile(string fileName)
        {
            string path = Environment.CurrentDirectory + $@"/{fileName}.config";
            if (File.Exists(path))
            {
                return File.ReadAllLines(path);
            }

            throw new Exception("File doesn't exist!");
        }
    }
}
