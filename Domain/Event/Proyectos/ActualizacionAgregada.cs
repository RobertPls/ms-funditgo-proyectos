using Shared.Core;

namespace Domain.Event.Proyectos
{
    public record ActualizacionAgregada : DomainEvent
    {
        public Guid ActualizacionId { get; private set; }

        public ActualizacionAgregada(Guid actualizacionId) : base(DateTime.Now)
        {
            ActualizacionId = actualizacionId;
        }
    }
}
