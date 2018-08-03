namespace Alore.API.Sql
{
    using System;
    using System.Data.Common;
    using System.Threading.Tasks;
    using Alore.API.Config;
    using MySql.Data.MySqlClient;

    public abstract class AloreDao
    {
        private readonly string _connectionString;

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
    }
}