using Domain.Event.Proyectos;
using MassTransit;
using MediatR;
using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.DomainEventHandler.Proyectos
{
    public class PublishingIntegrationEventWhenProyectoCreadoHandler : INotificationHandler<ConfirmedDomainEvent<ProyectoCreado>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishingIntegrationEventWhenProyectoCreadoHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<ProyectoCreado> notification, CancellationToken cancellationToken)
        {
            Shared.IntegrationEvents.ProyectoCreado evento = new Shared.IntegrationEvents.ProyectoCreado()
            {
                ProyectoId = notification.DomainEvent.ProyectoId,
                Titulo = notification.DomainEvent.Titulo,
            };
            await _publishEndpoint.Publish<Shared.IntegrationEvents.ProyectoCreado>(evento);


        }
    }
}
