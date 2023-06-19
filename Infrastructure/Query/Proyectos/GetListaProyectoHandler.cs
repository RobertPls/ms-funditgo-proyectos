using Application.Dto.Proyectos;
using Application.UseCase.Query.Proyectos;
using Infrastructure.EntityFramework.Context;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.Proyectos
{
    internal class GetListaProyectoHandler : IRequestHandler<GetListaProyectoQuery, IEnumerable<ProyectoDto>>
    {
        private readonly DbSet<ProyectoReadModel> proyecto;
        public GetListaProyectoHandler(ReadDbContext dbContext)
        {
            proyecto = dbContext.Proyecto;
        }
        public async Task<IEnumerable<ProyectoDto>> Handle(GetListaProyectoQuery request, CancellationToken cancellationToken)
        {
            var query = proyecto.AsNoTracking().AsQueryable();

            if (!string.IsNullOrEmpty(request.TituloSearchTerm))
            {
                query = query.Where(x => x.Titulo.ToLower().Contains(request.TituloSearchTerm.ToLower()));
            }
            var lista = await query.Select(x => new ProyectoDto
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Descripcion = x.Descripcion,
                Monto = x.Monto,
                Creador = new UsuarioDto { Id = x.Creador.Id, NombreCompleto=x.Creador.NombreCompleto},
                Comentarios = x.Comentarios.Select(c => new ComentarioDto
                {
                    Id = c.Id,
                    Texto= c.Texto,
                    Usuario = new UsuarioDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },

                }).ToList(),
                Colaboradores = x.Colaboradores.Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Usuario = new UsuarioDto { Id = c.Usuario.Id, NombreCompleto = c.Usuario.NombreCompleto },
                }).ToList()
            }).ToListAsync();
            return lista;
        }
    }
}
