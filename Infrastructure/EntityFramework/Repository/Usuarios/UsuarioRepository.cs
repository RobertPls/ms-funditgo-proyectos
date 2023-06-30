using Domain.Event.Proyectos;
using Domain.Event.Usuarios;
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
            return await _context.Usuario
                .Include(p => p.ProyectosFavoritos)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Usuario obj)
        {
            _context.Usuario.Remove(obj);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Usuario obj)
        {
            foreach (var e in obj.DomainEvents)
            {
                if (e is ProyectoFavoritoAgregado)
                {
                    var evento = (ProyectoFavoritoAgregado)e;
                    var proyectoFavorito = obj.ProyectosFavoritos.FirstOrDefault(c => c.Id == evento.ProyectoFavoritoId);
                    await _context.ProyectoFavorito.AddAsync(proyectoFavorito);
                }
                if (e is ProyectoFavoritoEliminado)
                {
                    var evento = (ProyectoFavoritoEliminado)e;
                    var proyectoFavorito = await _context.ProyectoFavorito.FindAsync(evento.ProyectoFavoritoId);
                    _context.ProyectoFavorito.Remove(proyectoFavorito);
                }
            }
            _context.Usuario.Update(obj);
        }

    }
}
