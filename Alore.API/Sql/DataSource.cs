namespace Alore.API.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    public abstract class DataSource<TEntity>
        where TEntity : new()
    {
        private readonly PropertyInfo[] _propertyInfos;
        private readonly Dictionary<string, string> _columnToAttribute;
        private readonly string _tableName;

        protected DataSource()
        {
            _propertyInfos = typeof(TEntity).GetProperties();
            _columnToAttribute = new Dictionary<string, string>();

            _tableName =
                ((AloreTableAttribute) Attribute.GetCustomAttribute(typeof(TEntity), typeof(AloreTableAttribute)))
                .TableName;

            foreach (PropertyInfo prop in _propertyInfos)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    if (attr is AloreColumnAttribute aloreColumn)
                    {
                        _columnToAttribute.Add(aloreColumn.Column, prop.Name);
                    }
                }
            }
        }

        protected async Task<TEntity> GetEntityByValue(object value, string column)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT ");

            for (int i = _propertyInfos.Length - 1; i >= 0; i--)
            {
                object[] attrs = _propertyInfos[i].GetCustomAttributes(true);

                foreach (object attr in attrs)
                {
                    if (attr is AloreColumnAttribute aloreColumn)
                    {
                        if (i == 0)
                        {
                            stringBuilder.Append(aloreColumn.Column).Append(" ");
                            break;
                        }

                        stringBuilder.Append(aloreColumn.Column).Append(", ");
                    }
                }
            }

            stringBuilder.Append("FROM ").Append(_tableName).Append(" WHERE ").Append(column).Append(" = ")
                .Append(value).Append(";");

            TEntity tEntity = new TEntity();

            using (MySqlConnection mysqlConnection = new MySqlConnection(""))
            {
                await mysqlConnection.OpenAsync();
                MySqlCommand command = mysqlConnection.CreateCommand();
                command.CommandText = stringBuilder.ToString();

                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (!reader.HasRows) return tEntity;

                    if (reader.Read())
                    {
                        for (int i = reader.FieldCount - 1; i >= 0; i--)
                        {
                            if (_columnToAttribute.TryGetValue(reader.GetName(i), out string property))
                            {
                                tEntity.
                            }
                        }
                    }
                }
            }

            return tEntity;
        }
    }
}