namespace Alore.API.Sql
{
    using System;
    using System.Data;
    using System.Threading.Tasks;

    public interface IAloreConnection : IDbConnection
    {
        /// <summary>
        /// Begins an async transation.
        /// </summary>
        /// <returns>The transaction upon task completion.</returns>
        Task<IDbTransaction> BeginTransactionAsync();

        /// <summary>
        /// Open the connection asynchronously.
        /// </summary>
        /// <returns>The connection opened upon task completion.</returns>
        Task OpenAsync();

        /// <summary>
        /// Close the connection asynchronously.
        /// </summary>
        /// <returns>The connection closed upon task completion.</returns>
        Task CloseAsync();
    }
}
