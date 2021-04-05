using System;
using EpolSoft.BusinessLayer.Services;
using EpolSoft.BusinessLayer.Services.Interfaces;
using EpolSoft.DataAccessLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.BusinessLayer
{
    public static class IoC
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<ICustomerService, CustomerService>();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            serviceCollection.RegisterDataAccessLayer(configuration);

            return serviceCollection;
        }
    }
}
