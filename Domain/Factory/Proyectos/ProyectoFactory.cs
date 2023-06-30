using Domain.Model.Proyectos;

namespace Domain.Factory.Proyectos
{
    public class ProyectoFactory : IProyectoFactory
    {
        public Proyecto Crear(Guid creadorId, Guid tipoProyectoId, string titulo, string descripcion, string historia, string compromisoAmbiental, decimal donacionEsperada, decimal donacionMinima)
        {
            return new Proyecto(creadorId, tipoProyectoId, titulo, descripcion, historia, compromisoAmbiental, donacionEsperada, donacionMinima);
        }
    }
}
