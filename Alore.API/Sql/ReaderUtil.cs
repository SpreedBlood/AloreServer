namespace Alore.API.Sql
{
    using System.Data.Common;

    public static class ReaderUtil
    {
        public static T Read<T>(this DbDataReader reader, string columnName) =>
            (T)reader[columnName];
    }
}
