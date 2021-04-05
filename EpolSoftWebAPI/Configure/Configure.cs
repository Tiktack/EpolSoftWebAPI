using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.WebAPI.Configure
{
    public static class Configure
    {
        public static IServiceCollection RegisterServies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return BusinessLayer.Configure.Configure.RegisterServies(serviceCollection, configuration);
        }
    }
}
