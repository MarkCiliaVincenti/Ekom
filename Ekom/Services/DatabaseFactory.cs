using Ekom.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Ekom.Services
{
    public class DatabaseFactory
    {
        readonly string _connectionString;

        public DatabaseFactory(IConfiguration configuration)
        {
            var connectionStringName
                = configuration["ConnectionStrings:umbracoDbDSN"]
                ?? "umbracoDbDSN";
            _connectionString = configuration.GetConnectionString(connectionStringName);
        }

        public DbContext GetDatabase() => new DbContext();
        public SqlConnection GetSqlConnection() => new SqlConnection(_connectionString);
    }
}
