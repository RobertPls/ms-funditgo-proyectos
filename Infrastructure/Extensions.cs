using Application;
using Domain.Repository.Proyectos;
using Domain.Repository.Usuarios;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.Repository.Proyectos;
using Infrastructure.EntityFramework.Repository.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Core;
using System.Reflection;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAplication();
            var connectionString = configuration.GetConnectionString("FunditGoProyectoConnection");
            services.AddDbContext<ReadDbContext>(context => { context.UseSqlServer(connectionString); });
            services.AddDbContext<WriteDbContext>(context => { context.UseSqlServer(connectionString); });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProyectoRepository, ProyectoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
