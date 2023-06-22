using MediatR;

namespace Application.UseCase.Command.Proyectos.AgregarActualizacion
{
    public record AgregarActualizacionCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Descripcion { get; set; }

    }
}
