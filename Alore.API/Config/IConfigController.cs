namespace Alore.API.Config
{
    public interface IConfigController
    {
        /// <summary>
        /// Tries to get the configuration model.
        /// </summary>
        /// <typeparam name="TConfig">The configuration model.</typeparam>
        /// <param name="name">The configuration file name.</param>
        /// <returns>The configuration or throws exception if it doesn't exist.</returns>
        TConfig Get<TConfig>(string name) where TConfig : AbstractConfig;
    }
}
