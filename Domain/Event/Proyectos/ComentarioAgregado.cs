using SharedKernel.Core;

namespace Domain.Event.Proyectos
{
    public record ComentarioAgregado : DomainEvent
    {
        public Guid ComentarioId { get; private set; }

        public ComentarioAgregado(Guid comentarioId) : base(DateTime.Now)
        {
            ComentarioId = comentarioId;
        }
    }
}
