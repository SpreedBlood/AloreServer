namespace Alore.API.Sql
{
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Threading.Tasks;
    using Alore.API.Config;
    using MySql.Data.MySqlClient;

    public abstract class AloreDao : IDisposable
    {
        private readonly string _connectionString;
         private readonly IList<KeyValuePair<string, object[]>> _insertQueries;

        protected AloreDao(IConfigController configController)
        {
            DatabaseConfig config = configController.Get<DatabaseConfig>("database");
            MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = config.User,
                Server = config.Host,
                Database = config.Database,
                Port = uint.Parse(config.Port),
                Password = config.Password
            };
            _connectionString = stringBuilder.ToString();
            _insertQueries = new List<KeyValuePair<string, object[]>>();
        }

        protected async Task CreateTransaction(Action<MySqlTransaction> transaction)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (MySqlTransaction mysqlTransaction = await connection.BeginTransactionAsync())
                {
                    transaction(mysqlTransaction);
                    mysqlTransaction.Commit();
                }

                await connection.CloseAsync();
            }
        }

        protected async Task QueueInsert(string commandText, params object[] parameters)
        {
            _insertQueries.Add(new KeyValuePair<string, object[]>(commandText, parameters));

            if (_insertQueries.Count == 10)
            {
                await CreateTransaction(async transaction =>
                {
                    foreach (KeyValuePair<string, object[]> insertQuery in _insertQueries)
                    {
                        await Insert(transaction, insertQuery.Key, insertQuery.Value);
                    }
                });
            }
        }

        protected async Task<int> Insert(MySqlTransaction transaction, string commandText, params object[] parameters)
        {
            try
            {
                var command = transaction.Connection.CreateCommand();
                command.CommandText = commandText;
                AddParameters(command, parameters);

                return await command.ExecuteNonQueryAsync();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

            return -1;
        }

        protected async Task<int> Delete(MySqlTransaction transaction, string commandText, params object[] parameters)
        {
            try
            {
                var command = transaction.Connection.CreateCommand();
                command.CommandText = commandText;
                AddParameters(command, parameters);

                return await command.ExecuteNonQueryAsync();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

            return -1;
        }

        protected async Task<int> Replace(MySqlTransaction transaction, string commandText, params object[] parameters)
        {
            try
            {
                var command = transaction.Connection.CreateCommand();
                command.CommandText = commandText;
                AddParameters(command, parameters);
                return await command.ExecuteNonQueryAsync();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

            return -1;
        }

        protected async Task Select(MySqlTransaction transaction, Action<DbDataReader> reader, string commandText, params object[] parameters)
        {
            try
            {
                var command = transaction.Connection.CreateCommand();
                command.CommandText = commandText;
                AddParameters(command, parameters);

                using (var dataReader = await command.ExecuteReaderAsync())
                {
                    reader(dataReader);
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                transaction.Rollback();
            }

        }

        private static void AddParameters(MySqlCommand command, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.AddWithValue($"@{i}", parameters[i]);
            }
        }

        public async void Dispose()
        {
            await CreateTransaction(async transaction =>
            {
                foreach (KeyValuePair<string, object[]> insertQuery in _insertQueries)
                {
                    await Insert(transaction, insertQuery.Key, insertQuery.Value);
                }
            });
        }
    }
}