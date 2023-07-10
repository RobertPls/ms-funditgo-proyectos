using Application.UseCase.Command.Proyectos.CompletarDonacion;
using MassTransit;
using MediatR;
using Shared.IntegrationEvents;

namespace Application.UseCase.Consumers
{

    public class DonacionCompletadaConsumer : IConsumer<DonacionCompletada>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "donacion-completada-exchange";
        public const string QueueName = "donacion-completada-pagos";

        public DonacionCompletadaConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<DonacionCompletada> context)
        {
            DonacionCompletada @event = context.Message;
            CompletarDonacionCommand command = new CompletarDonacionCommand(@event.ProyectoId, @event.DonacionId);
            await _mediator.Send(command);

        }
    }
}
