using MediatR;

namespace Application.UseCase.Command.Proyectos.RechazarProyecto
{
    public record RechazarProyectoCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
    }
}
