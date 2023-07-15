using Shared.Core;

namespace Domain.Event.Proyectos
{
    public record ProyectoCreado : DomainEvent
    {

        public Guid ProyectoId { get; set; }
        public string Titulo { get; set; }

        public ProyectoCreado(Guid proyectoId, string titulo) : base(DateTime.Now)
        {
            ProyectoId = proyectoId;
            Titulo = titulo;
        }
    }
}
