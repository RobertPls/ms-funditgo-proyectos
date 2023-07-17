using Application.UseCase.Command.Usuarios.CrearUsuario;
using MassTransit;
using MediatR;
using Shared.IntegrationEvents;

namespace Application.UseCase.Consumers
{
    public class UsuarioCreadoConsumer : IConsumer<UsuarioCreado>
    {
        private readonly IMediator _mediator;
        public const string ExchangeName = "usuario-creado-exchange";
        public const string QueueName = "usuario-creado-security";

        public UsuarioCreadoConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<UsuarioCreado> context)
        {
            UsuarioCreado @event = context.Message;
            CrearUsuarioCommand command = new CrearUsuarioCommand(@event.UsuarioId, @event.NombreCompleto, @event.UserName);
            await _mediator.Send(command);

        }
    }
}
