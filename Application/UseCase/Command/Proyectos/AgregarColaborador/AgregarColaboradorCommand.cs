using MediatR;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public record AgregarColaboradorCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid UsuarioQueRealizaLaAccionId { get; set; }

    }
}
