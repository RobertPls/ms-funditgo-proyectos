using Domain.Model.Proyectos;

namespace Domain.Factory.Proyectos
{
    public class ProyectoFactory : IProyectoFactory
    {
        public Proyecto Crear(Guid creadorId, Guid tipoProyectoId, string titulo, string descripcion, decimal donacionEsperada)
        {
            return new Proyecto(creadorId, tipoProyectoId, titulo, descripcion, donacionEsperada);
        }
    }
}
