using Domain.Model.Proyectos;
using Domain.Model.Usuarios;

namespace Domain.Factory.Proyectos
{
    public interface IUsuarioFactory
    {
        Usuario Crear(Guid id, string nombreCompleto);
    }
}
