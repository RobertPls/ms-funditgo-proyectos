using MediatR;

namespace Application.UseCase.Command.Proyectos.AceptarProyecto
{
    public record AceptarProyectoCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
    }
}
