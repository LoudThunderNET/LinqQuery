using DataAccess;
using DataAccess.Abstraction.Repository;
using DataAccess.EntityFramework;
using Domain.Entities;
using Infrastructure;
using LinqQuery.Extensions;
using LinqQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IQueryUsage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContextPool<BlogContext>(o =>
            {
                o.UseSqlServer("Data Source=HOME-PC\\SQLEXPRESS;Initial Catalog=BlogDb;User ID=sa;Password=123456;Pooling=False");
                o.UseLazyLoadingProxies();
            });
            services.AddScoped<DbContext, BlogContext>();
            services.AddTransient(typeof(IRepository<>), typeof(ReadOnlyRepository<>));
            services.AddTransient(typeof(IMutable<>), typeof(MutableRepository<>));
            services.AddLogging();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .MinimumLevel.Information()
                .CreateLogger();

            services.AddSingleton<ILoggerFactory>(services =>
            {
                var factory = new SerilogLoggerFactory(null, false, null);

                foreach (var provider in services.GetServices<ILoggerProvider>())
                    factory.AddProvider(provider);

                return factory;
            });

            var serviceProvider = services.BuildServiceProvider();

            var blogRepository =  serviceProvider.GetRequiredService<IRepository<Blog>>();

            var blog = await blogRepository.FindAsync(1);
            var blogA = await blogRepository
                .ExcecuteQueryAsync(b => b
                .Where(t => t.UserId == 2)
                .Select(b => new 
                { 
                    b.CreationDate, 
                    b.Title, 
                    b.Posts 
                }).FirstOrDefault());

            Log.CloseAndFlush();
        }
    }
}
