using Microsoft.EntityFrameworkCore;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory
    {
        private readonly string _connectionString;

        public SimpleTraderDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SimpleTraderDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            
            options.UseMySql(_connectionString, MySqlServerVersion.AutoDetect(_connectionString),
                b => b.MigrationsAssembly("SimpleTrader.EntityFramework"));

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
