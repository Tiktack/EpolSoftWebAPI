using System;
using Microsoft.Extensions.DependencyInjection;

namespace EpolSoft.Common.Configure
{
    public interface IConfigure
    {
        void RegisterServies(IServiceCollection serviceCollection) => throw new Exception("Services are not registerd");
    }
}
