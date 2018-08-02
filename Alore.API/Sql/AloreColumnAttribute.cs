namespace Alore.API.Sql
{
    using System;

    /// <summary>
    /// Deprecated!
    /// </summary>
    public class AloreColumnAttribute : Attribute
    {
        public string ColumnName { get; }

        public AloreColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}