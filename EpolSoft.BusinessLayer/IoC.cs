using System;
using EpolSoft.BusinessLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.BusinessLayer.Configure
{
    public static class IoC
    {
        public static IServiceCollection RegisterServies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            serviceCollection.RegisterServies(configuration);

            return serviceCollection;
        }
    }
}
