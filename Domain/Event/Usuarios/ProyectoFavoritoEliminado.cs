using SharedKernel.Core;

namespace Domain.Event.Usuarios
{
    public record ProyectoFavoritoEliminado : DomainEvent
    {
        public Guid ProyectoFavoritoId { get; private set; }

        public ProyectoFavoritoEliminado(Guid proyectoFavoritoId) : base(DateTime.Now)
        {
            ProyectoFavoritoId = proyectoFavoritoId;
        }
    }
}
