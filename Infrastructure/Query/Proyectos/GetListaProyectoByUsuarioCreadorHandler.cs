using Application.Dto.Proyectos;
using Application.Dto.TiposProyectos;
using Application.Dto.Usuarios;
using Application.UseCase.Query.Proyectos;
using Domain.Model.Proyectos;
using Domain.Model.Proyectos.Enum;
using Domain.Model.Usuarios;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.Query.Proyectos.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Proyectos
{

    internal class GetListaProyectoByUsuarioCreadorHandler : IRequestHandler<GetListaProyectoByUsuarioCreadorQuery, IEnumerable<ProyectoSimpleDto>>
    {
        private readonly DbSet<ProyectoReadModel> proyectos;
        public GetListaProyectoByUsuarioCreadorHandler(ReadDbContext dbContext)
        {
            proyectos = dbContext.Proyecto;
        }
        public async Task<IEnumerable<ProyectoSimpleDto>> Handle(GetListaProyectoByUsuarioCreadorQuery request, CancellationToken cancellationToken)
        {
            var query = proyectos.AsNoTracking()
                .Include(p => p.TipoProyecto)
                .Include(p => p.Donaciones)
                .Where(x => x.CreadorId == request.UsuarioId)
                .AsQueryable();

            var lista = await query.Select(proyecto => ProyectoMapper.MapToProyectoSimpleDto(proyecto)).ToListAsync();


            return lista;
        }
    }
}
