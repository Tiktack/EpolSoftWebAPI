using EpolSoft.BusinessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.WebAPI
{
    public static class IoC
    {
        public static IServiceCollection RegisterWeb(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            return serviceCollection.RegisterBusinessLayer(configuration);
        }
    }
}
