using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            string connectionString = "Server=127.0.0.1;Database=dbcsharp;User=csharp;Password=csharp!@;";
            
            options.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString));

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
