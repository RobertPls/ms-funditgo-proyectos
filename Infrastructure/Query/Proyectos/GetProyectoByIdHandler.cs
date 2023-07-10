using Application.Dto.Proyectos;
using Application.Dto.TiposProyectos;
using Application.Dto.Usuarios;
using Application.UseCase.Query.Proyectos;
using Domain.Model.Proyectos.Enum;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.Query.Proyectos.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Proyectos
{
    internal class GetProyectoByIdHandler : IRequestHandler<GetProyectoByIdQuery, ProyectoDto>
    {
        private readonly DbSet<ProyectoReadModel> proyectos;
        public GetProyectoByIdHandler(ReadDbContext dbContext)
        {
            proyectos = dbContext.Proyecto;
        }
        public async Task<ProyectoDto> Handle(GetProyectoByIdQuery request, CancellationToken cancellationToken)
        {

            var proyecto = await proyectos.AsNoTracking()
                .Include(p => p.Creador)
                .Include(p => p.TipoProyecto)
                .Include(p => p.Comentarios)
                    .ThenInclude(c => c.Usuario)
                .Include(p => p.Colaboradores)
                    .ThenInclude(c => c.Usuario)
                .Include(p => p.Actualizaciones)
                    .ThenInclude(c => c.Usuario)
                .Include(p => p.Donaciones)
                    .ThenInclude(c => c.Usuario)
                .FirstOrDefaultAsync(x => x.Id == request.ProyectoId);

            if (proyecto == null)
            {
                return null;
            }

            return ProyectoMapper.MapToProyectoDto(proyecto);
        }
    }
}
