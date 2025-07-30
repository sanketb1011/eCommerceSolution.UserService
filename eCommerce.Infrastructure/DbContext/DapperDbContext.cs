using AutoMapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string? _connctionString = _configuration.GetConnectionString("postgresConnection");
            _connection = new NpgsqlConnection(_connctionString);
        }

        public IDbConnection dbConnection => _connection;
    }
}
