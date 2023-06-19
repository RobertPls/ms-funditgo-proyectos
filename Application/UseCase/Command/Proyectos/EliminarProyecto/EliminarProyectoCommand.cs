using MediatR;

namespace Application.UseCase.Command.Proyectos.EliminarProyecto
{
    public record EliminarProyectoCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
    }
}
