using Application.UseCase.Command.Proyectos.EnviarProyectoARevision;
using MassTransit;
using MediatR;
using Shared.IntegrationEvents;

namespace Application.UseCase.Consumers
{
    public class RequisitosProyectoCompletadoConsumer : IConsumer<RequisitoProyectoCompletado>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "requisito-proyecto-completado-exchange";
        public const string QueueName = "requisito-proyecto-completado-configuracion";

        public RequisitosProyectoCompletadoConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<RequisitoProyectoCompletado> context)
        {
            RequisitoProyectoCompletado @event = context.Message;
            EnviarProyectoARevisionCommand command = new EnviarProyectoARevisionCommand(@event.ProyectoId);
            await _mediator.Send(command);

        }
    }
}
