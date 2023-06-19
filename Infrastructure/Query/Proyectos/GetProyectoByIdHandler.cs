using Application.Dto.Proyectos;
using Application.UseCase.Query.Proyectos;
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
            var proyecto = await proyectos.AsNoTracking()
                .Include(p => p.Creador)
                .Include(p => p.Comentarios)
                    .ThenInclude(c => c.Usuario)
                .Include(p => p.Colaboradores)
                    .ThenInclude(c => c.Usuario)
                .FirstOrDefaultAsync(x => x.Id == request.ProyectoId);

            if (proyecto == null)
            {
                return null;
            }
            System.Diagnostics.Debug.WriteLine(proyecto.Comentarios.Count());
            return new ProyectoDto
            {
                Id = proyecto.Id,
                Titulo = proyecto.Titulo,
                Descripcion = proyecto.Descripcion,
                Monto = proyecto.Monto,
                Creador = new UsuarioDto { Id = proyecto.Creador.Id, NombreCompleto = proyecto.Creador.NombreCompleto },
                Comentarios = proyecto.Comentarios.Select(c => new ComentarioDto
                {
                    Id = c.Id,
                    Texto = c.Texto,
                    Usuario = new UsuarioDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },

                }).ToList(),
                Colaboradores = proyecto.Colaboradores.Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Usuario = new UsuarioDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },
                }).ToList()
            };
        }
    }
}
