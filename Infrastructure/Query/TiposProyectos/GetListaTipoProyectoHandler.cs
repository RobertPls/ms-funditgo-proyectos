using Application.Dto.Proyectos;
using Application.Dto.TiposProyectos;
using Application.Dto.Usuarios;
using Application.UseCase.Query.TiposProyectos;
using Domain.Model.Proyectos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using Infrastructure.Query.Proyectos.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.TiposProyectos
{
    internal class GetListaTipoProyectoHandler : IRequestHandler<GetListaTipoProyectoQuery, IEnumerable<TipoProyectoDto>>
    {
        private readonly DbSet<TipoProyectoReadModel> tiposProyectos;
        public GetListaTipoProyectoHandler(ReadDbContext dbContext)
        {
            tiposProyectos = dbContext.TipoProyecto;
        }
        public async Task<IEnumerable<TipoProyectoDto>> Handle(GetListaTipoProyectoQuery request, CancellationToken cancellationToken)
        {
            var query = tiposProyectos.AsNoTracking().AsQueryable();

            var lista = await query.Select(tipoProyecto => new TipoProyectoDto
            {
                Id = tipoProyecto.Id,
                Nombre = tipoProyecto.Nombre,
            }).ToListAsync();

            return lista;
        }
    }
}
