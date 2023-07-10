using Application.Dto.Proyectos;
using MediatR;

namespace Application.UseCase.Query.Proyectos
{
    public class GetListaProyectoQuery : IRequest<IEnumerable<ProyectoSimpleDto>>
    {
        public string? TituloSearchTerm { get; set; }
        public Guid? TipoProyectoId { get; set; }
        public string? Estado { get; set; }
        public string? FechaDesde { get; set; }
        public string? FechaHasta{ get; set; }
        public decimal? DonacionMinima { get; set; }

    }
}
