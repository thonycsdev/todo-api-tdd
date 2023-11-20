using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Repository.Extensions
{
    public static class ContextServiceBuilder
    {
        public static void AddContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }   
    }
}
