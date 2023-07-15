using Application;
using Application.UseCase.Consumers;
using Domain.Repository.Proyectos;
using Domain.Repository.TiposTipoProyectos;
using Domain.Repository.Usuarios;
using Infrastructure.EntityFramework;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.Repository.Proyectos;
using Infrastructure.EntityFramework.Repository.TiposProyectos;
using Infrastructure.EntityFramework.Repository.Usuarios;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.IntegrationEvents;
using Shared.Core;
using System.Reflection;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAplication();
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            services.AddDbContext<ReadDbContext>(context => { context.UseSqlServer(connectionString); });
            services.AddDbContext<WriteDbContext>(context => { context.UseSqlServer(connectionString); });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProyectoRepository, ProyectoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITipoProyectoRepository, TipoProyectoRepository>();

            AddRabbitMq(services, configuration);

            return services;
        }

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqHost = configuration["RabbitMq:Host"];
            var rabbitMqPort = configuration["RabbitMq:Port"];
            var rabbitMqUserName = configuration["RabbitMq:UserName"];
            var rabbitMqPassword = configuration["RabbitMq:Password"];

            services.AddMassTransit(config =>
            {
                config.AddConsumer<UsuarioCreadoConsumer>().Endpoint(endpoint => endpoint.Name = UsuarioCreadoConsumer.QueueName);
                config.AddConsumer<TipoProyectoCreadoConsumer>().Endpoint(endpoint => endpoint.Name = TipoProyectoCreadoConsumer.QueueName);
                config.AddConsumer<DonacionCompletadaConsumer>().Endpoint(endpoint => endpoint.Name = DonacionCompletadaConsumer.QueueName);

                config.UsingRabbitMq((context, cfg) =>
                {
                    var uri = string.Format("amqps://{0}:{1}@{2}:{3}", rabbitMqUserName, rabbitMqPassword, rabbitMqHost, rabbitMqPort) ;
                    cfg.Host(uri);

                    cfg.ReceiveEndpoint(UsuarioCreadoConsumer.QueueName, endpoint =>
                    {
                        endpoint.ConfigureConsumer<UsuarioCreadoConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(TipoProyectoCreadoConsumer.QueueName, endpoint =>
                    {
                        endpoint.ConfigureConsumer<TipoProyectoCreadoConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(DonacionCompletadaConsumer.QueueName, endpoint =>
                    {
                        endpoint.ConfigureConsumer<DonacionCompletadaConsumer>(context);
                    });
                });
            }
            );
        }
    }
}
