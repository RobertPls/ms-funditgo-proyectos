using Domain.Model.TiposProyectos;

namespace Domain.Factory.TiposProyectos
{
    public interface ITipoProyectoFactory
    {
        TipoProyecto Crear(Guid id, string nombre);
    }
}
