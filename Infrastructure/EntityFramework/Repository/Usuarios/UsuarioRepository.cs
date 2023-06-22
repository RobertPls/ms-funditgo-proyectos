using Domain.Model.Usuarios;
using Domain.Repository.Usuarios;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.Usuarios
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly WriteDbContext _context;

        public UsuarioRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Usuario obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Usuario?> FindByIdAsync(Guid id)
        {
            return await _context.Usuario.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Usuario obj)
        {
            _context.Usuario.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Usuario obj)
        {
            _context.Usuario.Update(obj);
            return Task.CompletedTask;
        }

    }
}
