namespace Alore.API.Sql
{
    using System;

    public class AloreColumnAttribute : Attribute
    {
        public string ColumnName { get; }

        public AloreColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}