using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheMeeting.BuildingBlocks.Application.Data;
using TheMeeting.BuildingBlocks.Domain;

namespace TheMeeting.BuildingBlocks.Infrastructure
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                this._connection = new SqlConnection(_connectionString);
                this._connection.Open();
            }

            return this._connection;
        }

        public IDbConnection CreateNewConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            return connection;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public void Dispose()
        {
            if (this._connection != null && this._connection.State == ConnectionState.Open)
            {
                this._connection.Dispose();
            }
        }
    }
}