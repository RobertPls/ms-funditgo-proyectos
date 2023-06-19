using Domain.Model.Proyectos;
using Domain.Model.Usuarios;

namespace Domain.Factory.Proyectos
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public Usuario Crear(Guid id, string nombreCompleto)
        {
            return new Usuario(id,nombreCompleto);
        }
    }
}
