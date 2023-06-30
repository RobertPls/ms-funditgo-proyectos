using Application.Dto.Proyectos;
using Application.Dto.TiposProyectos;
using Application.Dto.Usuarios;
using Application.UseCase.Query.Proyectos;
using Domain.Model.Proyectos.Enum;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
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
            var estadoCompletado = nameof(EstadoDonacion.Completado);

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

            return new ProyectoDto
            {
                Id = proyecto.Id,
                FechaCreacion = proyecto.FechaCreacion,
                Estado = proyecto.Estado,
                Titulo = proyecto.Titulo,
                Descripcion = proyecto.Descripcion,
                Historia = proyecto.Historia,
                CompromisoAmbiental = proyecto.CompromisoAmbiental,
                DonacionEsperada = proyecto.DonacionEsperada,
                DonacionRecibida = proyecto.DonacionRecibida,
                DonacionMinima = proyecto.DonacionMinima,
                Creador = new UsuarioSimpleDto { Id = proyecto.Creador.Id, NombreCompleto = proyecto.Creador.NombreCompleto },
                Tipo = new TipoProyectoDto {Id = proyecto.TipoProyecto.Id, Nombre = proyecto.TipoProyecto.Nombre },
                Comentarios = proyecto.Comentarios.Select(c => new ComentarioDto
                {
                    Id = c.Id,
                    Texto = c.Texto,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },

                }).ToList(),
                Colaboradores = proyecto.Colaboradores.Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },
                }).ToList(),
                Actualizaciones = proyecto.Actualizaciones.Select(c => new ActualizacionDto
                {
                    Id = c.Id,
                    Fecha = c.Fecha,
                    Descripcion = c.Descripcion,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },
                }).ToList(),
                Donaciones = proyecto.Donaciones.Where(d=>d.Estado==estadoCompletado).Select(c => new DonacionDto
                {
                    Id = c.Id,
                    Monto = c.Monto,
                    Usuario = new UsuarioSimpleDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },
                    Estado = c.Estado,
                }).ToList()
            };
        }
    }
}
