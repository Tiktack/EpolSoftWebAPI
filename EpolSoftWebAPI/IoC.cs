using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.WebAPI.Configure
{
    public static class IoC
    {
        public static IServiceCollection RegisterServies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.RegisterServies(configuration);
        }
    }
}
