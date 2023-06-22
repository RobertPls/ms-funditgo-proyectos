using Domain.Model.TiposProyectos;

namespace Domain.Factory.TiposProyectos
{
    public class TipoProyectoFactory : ITipoProyectoFactory
    {
        public TipoProyecto Crear(Guid id, string nombre)
        {
            return new TipoProyecto(id, nombre);
        }
    }
}
