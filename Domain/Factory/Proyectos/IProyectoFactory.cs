using Domain.Model.Proyectos;

namespace Domain.Factory.Proyectos
{
    public interface IProyectoFactory
    {
        Proyecto Crear(Guid creadorId, string titulo, string descripcion, decimal monto);
    }
}
