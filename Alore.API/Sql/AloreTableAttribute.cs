namespace Alore.API.Sql
{
    using System;

    public class AloreTableAttribute : Attribute
    {
        public string TableName { get; }

        public AloreTableAttribute(string tableName)
        {
            TableName = tableName;
        }
    }
}
