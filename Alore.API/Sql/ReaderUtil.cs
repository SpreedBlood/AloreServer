namespace Alore.API.Sql
{
    using System.Data.Common;

    public static class ReaderUtil
    {
        public static uint ReadUint(this DbDataReader reader, string columnName) =>
            (uint)reader[columnName];

        public static int ReadInt(this DbDataReader reader, string columnName) =>
            (int)reader[columnName];

        public static double ReadDouble(this DbDataReader reader, string columnName) =>
            (double)reader[columnName];

        public static string ReadString(this DbDataReader reader, string columnName) =>
            (string)reader[columnName];

        public static bool ReadBool(this DbDataReader reader, string columnName) =>
            (bool)reader[columnName];
    }
}
