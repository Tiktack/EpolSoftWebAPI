using System;
using EpolSoft.BusinessLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.BusinessLayer.Configure
{
    public static class Configure
    {
        public static IServiceCollection RegisterServies(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            var a = AppDomain.CurrentDomain.GetAssemblies();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            DataAccessLayer.Configure.Configure.RegisterServies(serviceCollection, configuration);

            return serviceCollection;
        }
    }
}
