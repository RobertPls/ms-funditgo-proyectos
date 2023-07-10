using Application.Dto.Proyectos;
using Application.Dto.Usuarios;
using Application.UseCase.Query.Usuarios;
using Domain.Model.Proyectos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.Query.Proyectos.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Usuarios
{
    internal class GetUsuarioByIdHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioDto>
    {
        private readonly DbSet<UsuarioReadModel> usuarios;
        public GetUsuarioByIdHandler(ReadDbContext dbContext)
        {
            usuarios = dbContext.Usuario;
        }
        public async Task<UsuarioDto> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await usuarios.AsNoTracking()
                .Include(u => u.ProyectosFavoritos)
                    .ThenInclude(pf => pf.Proyecto)
                        .ThenInclude(p => p.Donaciones)
                .Include(u => u.ProyectosFavoritos)
                    .ThenInclude(pf => pf.Proyecto)
                        .ThenInclude(p => p.TipoProyecto)
                .FirstOrDefaultAsync(x => x.Id == request.UsuarioId);


            if (usuario == null)
            {
                return null;
            }

            return new UsuarioDto
            {
                Id = usuario.Id,
                NombreCompleto = usuario.NombreCompleto,
                ProyectosFavoritos = usuario.ProyectosFavoritos.Select(c => new ProyectoFavoritoDto
                {
                    Id = c.Id,
                    Proyecto = ProyectoMapper.MapToProyectoSimpleDto(c.Proyecto)
                }).ToList(),
            };
        }
    }
}
