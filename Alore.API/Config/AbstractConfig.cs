namespace Alore.API.Config
{
    using System.Collections.Generic;
    using System.Reflection;

    public abstract class AbstractConfig
    {
        private readonly IDictionary<string, PropertyInfo> _fields;

        /// <summary>
        /// Initializes the dictionary with the field names to property.
        /// </summary>
        protected AbstractConfig()
        {
            _fields = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo propertyInfo in GetType().GetProperties())
            {
                foreach (object attr in propertyInfo.GetCustomAttributes(true))
                {
                    if (attr is ConfigField configField)
                    {
                        _fields.Add(configField.Field, propertyInfo);
                    }
                }
            }
        }

        /// <summary>
        /// This will assign the values from the config file to the properties.
        /// </summary>
        /// <param name="lines">The lines of text from the configuration file.</param>
        public void SetPropertyValues(string[] lines)
        {
            foreach (string line in lines)
            {
                string configField = line.Split("=")[0];
                object configValue = line.Split("=")[1];

                if (_fields.TryGetValue(configField, out PropertyInfo property))
                {
                    property.SetValue(this, configValue, null);
                }
            }
        }
    }
}