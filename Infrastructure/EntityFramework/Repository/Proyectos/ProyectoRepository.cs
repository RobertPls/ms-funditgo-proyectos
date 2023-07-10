using Domain.Event.Proyectos;
using Domain.Model.Proyectos;
using Domain.Repository.Proyectos;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repository.Proyectos
{
    internal class ProyectoRepository : IProyectoRepository
    {
        private readonly WriteDbContext _context;

        public ProyectoRepository(WriteDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Proyecto obj)
        {
            await _context.AddAsync(obj);
        }

        public async Task<Proyecto?> FindByIdAsync(Guid id)
        {
            return await _context.Proyecto
                .Include(p => p.Colaboradores)
                .Include(p => p.Comentarios)
                .Include(p => p.Actualizaciones)
                .Include(p => p.Donaciones)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task RemoveAsync(Proyecto obj)
        {
            _context.Proyecto.Remove(obj);
            return Task.CompletedTask;
        }

        public async Task UpdateAsync(Proyecto obj)
        {
            foreach (var e in obj.DomainEvents)
            {
                if (e is ActualizacionAgregada)
                {
                    var evento = (ActualizacionAgregada)e;
                    var actualizacion = obj.Actualizaciones.FirstOrDefault(c => c.Id== evento.ActualizacionId);
                    await _context.Actualizacion.AddAsync(actualizacion);
                }
                if (e is DonacionCreada)
                {
                    var evento = (DonacionCreada)e;
                    var donacion = obj.Donaciones.FirstOrDefault(c => c.Id == evento.DonacionId);
                    await _context.Donacion.AddAsync(donacion);
                }
                if (e is DonacionCompletada)
                {
                    var evento = (DonacionCompletada)e;
                    var donacion = obj.Donaciones.FirstOrDefault(c => c.Id == evento.DonacionId);
                    _context.Donacion.Update(donacion);
                }
                if (e is ColaboradorAgregado)
                {
                    var evento = (ColaboradorAgregado)e;
                    var colaborador = obj.Colaboradores.FirstOrDefault(c => c.UsuarioId == evento.UsuarioId);
                    await _context.Colaborador.AddAsync(colaborador);
                }
                if (e is ColaboradorEliminado)
                {
                    var evento = (ColaboradorEliminado)e;
                    var colaborador = await _context.Colaborador.FindAsync(evento.ColaboradorId);
                    _context.Colaborador.Remove(colaborador);
                }
                if (e is ComentarioAgregado)
                {
                    var evento = (ComentarioAgregado)e;
                    var comentario = obj.Comentarios.FirstOrDefault(c => c.Id == evento.ComentarioId);
                    await _context.Comentario.AddAsync(comentario);
                }
                if (e is ComentarioEliminado)
                {
                    var evento = (ComentarioEliminado)e;
                    var comentario = await _context.Comentario.FindAsync(evento.ComentarioId);
                    _context.Comentario.Remove(comentario);
                }
            }

            _context.Proyecto.Update(obj);
        }

    }
}
