using Application.Dto.Proyectos;
using Application.UseCase.Query.Proyectos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.Query.Proyectos.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Core;

namespace Infrastructure.Query.Proyectos
{
    internal class GetListaProyectoHandler : IRequestHandler<GetListaProyectoQuery, IEnumerable<ProyectoSimpleDto>>
    {
        private readonly DbSet<ProyectoReadModel> proyectos;
        public GetListaProyectoHandler(ReadDbContext dbContext)
        {
            proyectos = dbContext.Proyecto;
        }
        public async Task<IEnumerable<ProyectoSimpleDto>> Handle(GetListaProyectoQuery request, CancellationToken cancellationToken)
        {
            var query = proyectos
                .Include(p => p.TipoProyecto)
                .Include(p => p.Donaciones)
                .AsNoTracking()
                .AsQueryable();

            query = FiltrarPorTipoProyecto(query, request.TipoProyectoId);
            query = FiltrarPorFecha(query, request.FechaDesde, request.FechaHasta);
            query = FiltrarPorEstado(query, request.Estado);
            query = FiltrarPorTitulo(query, request.TituloSearchTerm);
            query = FiltrarPorDonacionMinima(query, request.DonacionMinima);

            var lista = await query.Select(proyecto => ProyectoMapper.MapToProyectoSimpleDto(proyecto)).ToListAsync();

            return lista;
        }

        private IQueryable<ProyectoReadModel> FiltrarPorTipoProyecto(IQueryable<ProyectoReadModel> query, Guid? tipoProyectoId)
        {
            if (tipoProyectoId != Guid.Empty && !string.IsNullOrEmpty(tipoProyectoId.ToString()))
            {
                query = query.Where(x => x.TipoProyectoId == tipoProyectoId);
            }

            return query;
        }

        private IQueryable<ProyectoReadModel> FiltrarPorFecha(IQueryable<ProyectoReadModel> query, string? fechaDesde, string? fechaHasta)
        {
            if (DateTime.TryParse(fechaDesde, out var fechaDesdeValue))
            {
                query = query.Where(x => x.FechaCreacion.Date >= fechaDesdeValue.Date);
            }

            if (DateTime.TryParse(fechaHasta, out var fechaHastaValue))
            {
                query = query.Where(x => x.FechaCreacion.Date <= fechaHastaValue.Date);
            }

            return query;
        }

        private IQueryable<ProyectoReadModel> FiltrarPorTitulo(IQueryable<ProyectoReadModel> query, string? tituloSearchTerm)
        {
            if (!string.IsNullOrEmpty(tituloSearchTerm))
            {
                query = query.Where(x => x.Titulo.ToLower().Contains(tituloSearchTerm.ToLower()));
            }

            return query;
        }

        private IQueryable<ProyectoReadModel> FiltrarPorDonacionMinima(IQueryable<ProyectoReadModel> query, decimal? donacionMinima)
        {
            if (donacionMinima.HasValue)
            {
                query = query.Where(x => x.DonacionMinima <= donacionMinima.Value);
            }

            return query;
        }
        private IQueryable<ProyectoReadModel> FiltrarPorEstado(IQueryable<ProyectoReadModel> query, string? estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                query = query.Where(x => x.Estado.ToLower().Contains(estado.ToLower()));
            }

            return query;
        }

    }
}
