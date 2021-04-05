using EpolSoft.DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.DataAccessLayer
{
    public static class IoC
    {
        public static IServiceCollection RegisterDataAccessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddDbContext<DbContext, DataBaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Database")));

            return serviceCollection;
        }
    }
}
