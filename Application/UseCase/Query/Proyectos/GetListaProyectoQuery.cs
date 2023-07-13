using Application.Dto.Proyectos;
using Application.Utils;
using MediatR;

namespace Application.UseCase.Query.Proyectos
{
    public class GetListaProyectoQuery : IRequest<PagedList<ProyectoSimpleDto>>
    {
        public required int Page {get; set;}
        public required int PageSize { get; set; }

        public string? TituloSearchTerm { get; set; }
        public Guid? TipoProyectoId { get; set; }
        public string? Estado { get; set; }
        public string? FechaDesde { get; set; }
        public string? FechaHasta{ get; set; }
        public decimal? DonacionMinima { get; set; }

    }
}
