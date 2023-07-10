using Domain.Factory.Proyectos;
using Domain.Factory.TiposProyectos;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IProyectoFactory, ProyectoFactory>();
            services.AddScoped<IUsuarioFactory, UsuarioFactory>();
            services.AddScoped<ITipoProyectoFactory, TipoProyectoFactory>();
            return services;
        }
    }
}
