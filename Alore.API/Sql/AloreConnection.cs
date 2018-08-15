namespace Alore.API.Sql
{
    using System.Data;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;

    internal class AloreConnection : IAloreConnection
    {
        private readonly MySqlConnection _connection;

        internal AloreConnection(MySqlConnection mySqlConnection)
        {
            _connection = mySqlConnection;
        }

        public string ConnectionString { get => _connection.ConnectionString; set => _connection.ConnectionString = value; }

        public int ConnectionTimeout => _connection.ConnectionTimeout;

        public string Database => _connection.Database;

        public ConnectionState State => _connection.State;

        public IDbTransaction BeginTransaction() => _connection.BeginTransaction();

        public IDbTransaction BeginTransaction(IsolationLevel il) => _connection.BeginTransaction(il);

        public Task<MySqlTransaction> BeginTransactionAsync() => _connection.BeginTransactionAsync();

        public void ChangeDatabase(string databaseName) => _connection.ChangeDatabase(databaseName);

        public void Close() => _connection.Close();

        public Task CloseAsync() => _connection.CloseAsync();

        public IDbCommand CreateCommand() => _connection.CreateCommand();

        public void Dispose() => _connection.Dispose();

        public void Open() => _connection.Open();

        public Task OpenAsync() => _connection.OpenAsync();
    }
}