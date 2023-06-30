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
    internal class GetListaDonacionesAProyectosByUsuarioDonadorHandler : IRequestHandler<GetListaDonacionesAProyectosByUsuarioDonadorQuery, IEnumerable<ProyectoSimpleConDonacionTotalSegunUsuarioDto>>
    {
        private readonly DbSet<ProyectoReadModel> proyectos;
        public GetListaDonacionesAProyectosByUsuarioDonadorHandler(ReadDbContext dbContext)
        {
            proyectos = dbContext.Proyecto;
        }
        public async Task<IEnumerable<ProyectoSimpleConDonacionTotalSegunUsuarioDto>> Handle(GetListaDonacionesAProyectosByUsuarioDonadorQuery request, CancellationToken cancellationToken)
        {
            var estadoCompletado = nameof(EstadoDonacion.Completado);

            var query = proyectos.AsNoTracking()
                .Include(p => p.Donaciones).AsQueryable();

            var lista = await query.Select(proyecto => ProyectoMapper.MapToProyectoSimpleConDonacionTotalSegunUsuarioDto(proyecto, request.UsuarioId)).ToListAsync();

            return lista;
        }

    }
}
