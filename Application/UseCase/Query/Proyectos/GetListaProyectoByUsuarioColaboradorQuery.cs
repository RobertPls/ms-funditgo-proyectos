using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCase.Query.Proyectos
{
    public class GetListaProyectoByUsuarioColaboradorQuery : IRequest<IEnumerable<ProyectoSimpleDto>>
    {
        public Guid UsuarioId { get; set; }
    }
}
