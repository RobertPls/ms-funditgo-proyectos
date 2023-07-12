using MediatR;

namespace Application.UseCase.Command.Proyectos.AgregarColaborador
{
    public record AgregarColaboradorCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public string UserNameUsuario { get; set; }
        public Guid EjecutorId { get; set; }

    }
}
