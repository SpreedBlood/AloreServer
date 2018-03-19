namespace Alore.API.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Reflection;

    public abstract class AloreModel
    {
        protected readonly Dictionary<string, PropertyInfo> _dbNameToProperty;

        protected AloreModel()
        {
            _dbNameToProperty = new Dictionary<string, PropertyInfo>();

            foreach (PropertyInfo propertyInfo in GetType().GetProperties())
            {
                foreach (object attr in propertyInfo.GetCustomAttributes(true))
                {
                    if (attr is AloreColumnAttribute aloreColumn)
                    {
                        _dbNameToProperty.Add(aloreColumn.ColumnName, propertyInfo);
                    }
                }
            }
        }

        public void SetPropertyValues(DbDataReader reader)
        {
            for (int i = reader.FieldCount - 1; i >= 0; i--)
            {
                if (_dbNameToProperty.TryGetValue(reader.GetName(i), out PropertyInfo property))
                {
                    property.SetValue(this, reader.GetValue(i), null);
                }
            }
        }
    }
}
