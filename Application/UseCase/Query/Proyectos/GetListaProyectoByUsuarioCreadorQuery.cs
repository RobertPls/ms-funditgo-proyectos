using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCase.Query.Proyectos
{
    public class GetListaProyectoByUsuarioCreadorQuery : IRequest<IEnumerable<ProyectoSimpleDto>>
    {
        public Guid UsuarioId { get; set; }
    }
}
