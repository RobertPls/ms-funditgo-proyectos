using Application.Dto.Proyectos;
using Application.UseCase.Query.Proyectos;
using Domain.Model.Proyectos.Enum;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.Query.Proyectos.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query.Proyectos
{

    internal class GetListaProyectoByUsuarioColaboradorHandler : IRequestHandler<GetListaProyectoByUsuarioColaboradorQuery, IEnumerable<ProyectoSimpleDto>>
    {
        private readonly DbSet<ProyectoReadModel> proyectos;
        public GetListaProyectoByUsuarioColaboradorHandler(ReadDbContext dbContext)
        {
            proyectos = dbContext.Proyecto;
        }
        public async Task<IEnumerable<ProyectoSimpleDto>> Handle(GetListaProyectoByUsuarioColaboradorQuery request, CancellationToken cancellationToken)
        {
            var estadoCompletado = nameof(EstadoDonacion.Completado);

            var query = proyectos.AsNoTracking()
                .Include(p => p.Donaciones)
                .Where(x => x.Colaboradores.Any(c => c.Usuario.Id == request.UsuarioId)).AsQueryable();

            var lista = await query.Select(proyecto => ProyectoMapper.MapToProyectoSimpleDto(proyecto)).ToListAsync();

            return lista;
        }

    }
}
