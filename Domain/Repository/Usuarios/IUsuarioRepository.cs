using Domain.Model.Usuarios;
using Shared.Core;

namespace Domain.Repository.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Task<Usuario?> FindByUserNameAsync(string userName);
        Task UpdateAsync(Usuario obj);
        Task RemoveAsync(Usuario obj);
    }
}
