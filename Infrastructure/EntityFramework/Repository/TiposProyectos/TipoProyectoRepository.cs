using Domain.Model.TiposProyectos;
using Domain.Repository.TiposTipoProyectos;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.TiposProyectos
{
    internal class TipoProyectoRepository : ITipoProyectoRepository
    {
        private readonly WriteDbContext _context;

        public TipoProyectoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TipoProyecto obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<TipoProyecto?> FindByIdAsync(Guid id)
        {
            return await _context.TipoProyecto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(TipoProyecto obj)
        {
            _context.TipoProyecto.Remove(obj);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TipoProyecto obj)
        {
            _context.TipoProyecto.Update(obj);
            return Task.CompletedTask;
        }

    }
}
