using MassTransit;
using MediatR;
using SharedKernel.Core;

namespace Application.UseCase.DomainEventHandler.Proyectos
{
    public class PublishingIntegrationEventWhenDonacionCreadaHandler : INotificationHandler<ConfirmedDomainEvent<Domain.Event.Proyectos.DonacionCreada>>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public PublishingIntegrationEventWhenDonacionCreadaHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(ConfirmedDomainEvent<Domain.Event.Proyectos.DonacionCreada> notification, CancellationToken cancellationToken)
        {
            Shared.IntegrationEvents.DonacionCreada evento = new Shared.IntegrationEvents.DonacionCreada()
            {
                DonacionId = notification.DomainEvent.DonacionId,
            };
            await _publishEndpoint.Publish<Shared.IntegrationEvents.DonacionCreada>(evento);


        }
    }
}
