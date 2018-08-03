namespace Alore.API.Config
{
    using System;

    public class ConfigField : Attribute
    {
        public string Field { get; }

        public ConfigField(string field)
        {
            Field = field;
        }
    }
}
