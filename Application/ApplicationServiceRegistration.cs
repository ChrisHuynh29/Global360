using Application.Commands.CreateToDo;
using Application.Commands.DeleteToDo;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped<CreateToDoCommandValidator, CreateToDoCommandValidator>();
            services.AddScoped<DeleteToDoCommandValidator, DeleteToDoCommandValidator>();
            return services;
        }
    }
}
