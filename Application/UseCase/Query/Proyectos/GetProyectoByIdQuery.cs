using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCase.Query.Proyectos
{
    public class GetProyectoByIdQuery : IRequest<ProyectoDto>
    {
        public Guid ProyectoId { get; set; }
    }
}
