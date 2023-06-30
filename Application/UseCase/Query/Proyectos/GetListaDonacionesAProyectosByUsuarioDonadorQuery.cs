using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCase.Query.Proyectos
{
    public class GetListaDonacionesAProyectosByUsuarioDonadorQuery : IRequest<IEnumerable<ProyectoSimpleConDonacionTotalSegunUsuarioDto>>
    {
        public Guid UsuarioId { get; set; }
    }
}
