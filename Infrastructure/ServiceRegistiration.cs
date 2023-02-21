using Application.Interfaces.ExternalServices;
using Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            
            services.AddScoped<ICheckService,MernisCheckServiceAdapter>();
            return services;
        }
    }
}
