using Domain.Model.Proyectos;

namespace Domain.Factory.Proyectos
{
    public class ProyectoFactory : IProyectoFactory
    {
        public Proyecto Crear(Guid creadorId, string titulo, string descripcion, decimal monto)
        {
            return new Proyecto(creadorId, titulo, descripcion, monto);
        }
    }
}
