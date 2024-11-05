using Microsoft.EntityFrameworkCore;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory
    {
        private readonly string _connectionString;
        //private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public SimpleTraderDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public SimpleTraderDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        //{
        //    _configureDbContext = configureDbContext;
        //}

        public SimpleTraderDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();

            //_configureDbContext(options);

            options.UseMySql(_connectionString, MySqlServerVersion.AutoDetect(_connectionString),
                b => b.MigrationsAssembly("SimpleTrader.EntityFramework"));

            //options.UseSqlite(_connectionString);

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
