using SharedKernel.Core;

namespace Domain.Event.Proyectos
{
    public record ProyectoCreado : DomainEvent
    {
        public Guid ProyectoId { get; private set; }
        public string Titulo { get; private set; }



        public ProyectoCreado(Guid proyectoId, string titulo) : base(DateTime.Now)
        {
            ProyectoId = proyectoId;
            Titulo = titulo;
        }
    }
}
