using Application.Dto.TiposProyectos;

namespace Application.Dto.Proyectos
{
    public class ProyectoSimpleDto
    {
        public Guid Id { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string TipoProyecto { get; set; }

        public string Descripcion { get; set; }

        public string Titulo { get; set; }

        public string Estado { get; set; }

        public decimal DonacionMinima { get; set; }

        public int PorcentajeDonaciones { get; set; }

        public int CantidadDonaciones { get; set; }

    }
}
