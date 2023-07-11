using SharedKernel.Core;

namespace Domain.Event.Proyectos
{
    public record DonacionCreada : DomainEvent
    {
        public Guid DonacionId { get; private set; }
        public Guid ProyectoId { get; private set; }

        public DonacionCreada(Guid donacionId, Guid proyectoId) : base(DateTime.Now)
        {
            DonacionId = donacionId;
            ProyectoId = proyectoId;
        }
    }
}
