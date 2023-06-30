using MediatR;

namespace Application.UseCase.Command.Proyectos.EnviarProyectoAObservacion
{
    public record EnviarProyectoAObservacionCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
    }
}
