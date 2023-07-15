using Shared.Core;

namespace Domain.Event.Proyectos
{
    public record ComentarioEliminado : DomainEvent
    {
        public Guid ComentarioId { get; private set; }

        public ComentarioEliminado(Guid comentarioId) : base(DateTime.Now)
        {
            ComentarioId = comentarioId;
        }
    }
}
