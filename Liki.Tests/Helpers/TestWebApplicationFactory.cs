using System.IO;
using Liki.Data.Contracts.Abstractions;
using Liki.Data.EntityFramework;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Liki.Tests.Helpers
{
    public class TestWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        private const string TestDbFileName = "tests.db";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.RemoveService(typeof(DbContextOptions<ApiDbContext>));
                services.RemoveService(typeof(ApiDbContext));
                services.RemoveService(typeof(IUnitOfWork));

                if (File.Exists(TestDbFileName))
                {
                    File.Delete(TestDbFileName);
                }

                services.AddEntityFrameworkSqlite()
                    .AddDbContext<ApiDbContext>(options => { options.UseSqlite($"Data Source={TestDbFileName}"); },
                        ServiceLifetime.Singleton,
                        ServiceLifetime.Singleton);
                services.AddSingleton<IUnitOfWork, UnitOfWork>();
            });
        }
    }
}