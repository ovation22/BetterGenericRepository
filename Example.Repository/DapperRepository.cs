using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Example.Repository.Interfaces;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Example.Repository
{
    public class DapperRepository<T> : IRepository<T> where T : class
    {
        private readonly string _tableName;
        private readonly string _connectionString;

        public DapperRepository(IConfiguration configuration)
        {
            _tableName = typeof(T).Name;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        internal IDbConnection Connection => new SqlConnection(_connectionString);

        public IEnumerable<T> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<T>($"SELECT * FROM {_tableName}");
            }
        }       

        public T Get(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Query<T>($"SELECT * FROM {_tableName} WHERE Id = @Id", 
                    new { Id = id }).FirstOrDefault();
            }
        }        
    }
}
