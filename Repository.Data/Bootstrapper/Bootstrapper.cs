
using IRepository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Repository.Data
{
    public static class Bootstrapper
    {

        public static string GetConnectionString { get; set; }

        public static DataContext.ApplicationDbContext AppDbContext { get; set; }
        public static void ResolveUnitOfWork(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext.ApplicationDbContext>(cnf =>
            {
                string fff = configuration.GetConnectionString("DBConString");
                cnf.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("DBConString"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

 
    }
}
