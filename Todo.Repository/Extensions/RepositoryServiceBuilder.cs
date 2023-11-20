using Microsoft.Extensions.DependencyInjection;
using Todo.Repository.Repositories.EntitiesRepository;
using Todo.Repository.Repositories.Interfaces;

namespace Repository.Extensions
{
    public static class RepositoryServiceBuilder
    { 
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
