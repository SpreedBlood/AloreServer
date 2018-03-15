namespace Alore.API.Sql
{
    using System;

    public class AloreColumnAttribute : Attribute
    {
        public string Column { get; }

        public AloreColumnAttribute(string columnName)
        {
            Column = columnName;
        }
    }
}
