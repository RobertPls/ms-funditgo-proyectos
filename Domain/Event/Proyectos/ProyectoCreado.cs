using Shared.Core;

namespace Domain.Event.Proyectos
{
    public record ProyectoCreado : DomainEvent
    {
        public Guid ProyectoId { get; set; }

        public Guid CreadorId { get; set; }

        public Guid TipoProyectoId { get; set; }

        public string Titulo { get; set; }
        public string Estado { get; set; }

        public ProyectoCreado(Guid proyectoId, Guid creadorId, Guid tipoProyectoId, string titulo, string estado) : base(DateTime.Now)
        {
            ProyectoId = proyectoId;
            CreadorId = creadorId;
            TipoProyectoId = tipoProyectoId;
            Titulo = titulo;
            Estado = estado;
        }
    }
}
