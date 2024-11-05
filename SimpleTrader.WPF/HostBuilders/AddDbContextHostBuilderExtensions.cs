using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleTrader.EntityFramework;
using SimpleTrader.FinancialModelingPrepAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                //string connectionString = context.Configuration.GetConnectionString("sqlite");
                string connectionString = context.Configuration.GetConnectionString("default");
                services.AddDbContext<SimpleTraderDbContext>(o => o.UseMySql(connectionString, MySqlServerVersion.AutoDetect(connectionString),
                                                            b => b.MigrationsAssembly("SimpleTrader.EntityFramework")));
                services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(connectionString));
                //Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlite(connectionString);
                //services.AddDbContext<SimpleTraderDbContext>(configureDbContext);
                //services.AddSingleton<SimpleTraderDbContextFactory>(new SimpleTraderDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
