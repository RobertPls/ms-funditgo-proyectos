using Application.UseCase.Command.TiposProyectos.CrearTipoProyecto;
using MassTransit;
using MediatR;
using Shared.IntegrationEvents;

namespace Application.UseCase.Consumers
{
    public class TipoProyectoCreadoConsumer : IConsumer<TipoProyectoCreado>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "tipo-proyecto-creado-exchange";
        public const string QueueName = "tipo-proyecto-creado-configuracion";

        public TipoProyectoCreadoConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<TipoProyectoCreado> context)
        {
            TipoProyectoCreado @event = context.Message;
            CrearTipoProyectoCommand command = new CrearTipoProyectoCommand(@event.TipoProyectoId, @event.Nombre);
            await _mediator.Send(command);

        }
    }
}
