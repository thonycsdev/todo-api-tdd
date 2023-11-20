using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Services.EntityServices;
using Todo.Services.Interfaces;

namespace Services.Extensions
{
    public static class ServiceServiceBuilder
    {
        public static void AddServiceBuilder(this IServiceCollection services)
        {
            services.AddScoped<IService<User>, UserService>();
        }
    }
}
