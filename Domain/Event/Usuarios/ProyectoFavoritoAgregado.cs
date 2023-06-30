using SharedKernel.Core;

namespace Domain.Event.Usuarios
{
    public record ProyectoFavoritoAgregado : DomainEvent
    {
        public Guid ProyectoFavoritoId { get; private set; }

        public ProyectoFavoritoAgregado(Guid proyectoFavoritoId) : base(DateTime.Now)
        {
            ProyectoFavoritoId = proyectoFavoritoId;
        }
    }
}
