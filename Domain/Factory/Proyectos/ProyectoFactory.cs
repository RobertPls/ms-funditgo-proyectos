using Domain.Event.Proyectos;
using Domain.Model.Proyectos;

namespace Domain.Factory.Proyectos
{
    public class ProyectoFactory : IProyectoFactory
    {
        public Proyecto Crear(Guid creadorId, Guid tipoProyectoId, string titulo, string descripcion, string historia, string compromisoAmbiental, decimal donacionEsperada, decimal donacionMinima)
        {
            var obj = new Proyecto(creadorId, tipoProyectoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
            var domainEvent = new ProyectoCreado(obj.Id, obj.CreadorId, obj.TipoProyectoId,obj.Titulo, obj.Estado);
            obj.AddDomainEvent(domainEvent);
            return obj;
        }
    }
}
