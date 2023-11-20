using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
