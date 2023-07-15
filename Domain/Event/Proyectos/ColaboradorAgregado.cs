using Shared.Core;

namespace Domain.Event.Proyectos
{
    public record ColaboradorAgregado : DomainEvent
    {
        public Guid UsuarioId { get; private set; }

        public ColaboradorAgregado(Guid usuarioId) : base(DateTime.Now)
        {
            UsuarioId = usuarioId;
        }
    }
}
