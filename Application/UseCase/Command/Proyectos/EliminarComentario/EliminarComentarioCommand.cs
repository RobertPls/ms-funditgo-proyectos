using MediatR;

namespace Application.UseCase.Command.Proyectos.EliminarColaborador
{
    public record EliminarComentarioCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid ComentarioId { get; set; }
        public Guid EjecutorId { get; set; }

    }
}
