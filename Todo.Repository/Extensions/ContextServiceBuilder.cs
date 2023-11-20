using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Todo.Repository;

namespace Repository.Extensions
{
    public static class ContextServiceBuilder
    {
        public static void ConfigureDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }   
    }
}
