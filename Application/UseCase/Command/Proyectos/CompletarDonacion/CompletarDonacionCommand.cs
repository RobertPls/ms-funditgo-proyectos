using MediatR;

namespace Application.UseCase.Command.Proyectos.CompletarDonacion
{
    public record CompletarDonacionCommand : IRequest<Guid>
    {
        public Guid ProyectoId { get; set; }
        public Guid DonacionId { get; set; }

        public CompletarDonacionCommand(Guid proyectoId, Guid donacionId)
        {
            ProyectoId = proyectoId;
            DonacionId = donacionId;
        }
    }

}
