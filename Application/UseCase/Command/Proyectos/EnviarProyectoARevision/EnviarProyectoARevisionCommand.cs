using MediatR;

namespace Application.UseCase.Command.Proyectos.EnviarProyectoARevision
{
    public record EnviarProyectoARevisionCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
    }
}
