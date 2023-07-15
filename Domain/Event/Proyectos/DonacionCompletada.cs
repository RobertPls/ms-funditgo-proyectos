using Shared.Core;

namespace Domain.Event.Proyectos
{
    public record DonacionCompletada : DomainEvent
    {
        public Guid DonacionId { get; private set; }


        public DonacionCompletada(Guid donacionId) : base(DateTime.Now)
        {
            DonacionId = donacionId;
        }
    }
}
