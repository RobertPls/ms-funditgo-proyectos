using Domain.Event.Proyectos;
using MassTransit;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.DomainEventHandler.Proyectos
{
    public class PublishingIntegrationEventWhenDonacionCreadaHandler : INotificationHandler<ConfirmedDomainEvent<DonacionCreada>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishingIntegrationEventWhenDonacionCreadaHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<DonacionCreada> notification, CancellationToken cancellationToken)
        {
            Shared.IntegrationEvents.DonacionCreada evento = new Shared.IntegrationEvents.DonacionCreada()
            {
                DonacionId = notification.DomainEvent.DonacionId,
                ProyectoId = notification.DomainEvent.ProyectoId,
                Monto = notification.DomainEvent.Monto
            };
            await _publishEndpoint.Publish<Shared.IntegrationEvents.DonacionCreada>(evento);


        }
    }
}
