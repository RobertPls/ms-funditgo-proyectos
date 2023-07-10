using Domain.Model.Proyectos;
using MediatR;

namespace Application.UseCase.Command.Proyectos.EnviarProyectoARevision
{
    public record EnviarProyectoARevisionCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }


        public EnviarProyectoARevisionCommand(Guid proyectoId)
        {
            ProyectoId = proyectoId;
        }
    }
}
