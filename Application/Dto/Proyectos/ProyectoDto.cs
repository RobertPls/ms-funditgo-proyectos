using Application.Dto.TiposProyectos;

namespace Application.Dto.Proyectos
{
    public class ProyectoDto
    {
        public Guid Id { get; set; }

        public DateTime FechaCreacion { get; set; }

        public UsuarioDto Creador { get; set; }

        public TipoProyectoDto Tipo { get; set; }

        public required string Titulo { get; set; }

        public required string Descripcion { get; set; }

        public decimal DonacionEsperada { get; set; }

        public decimal DonacionRecibida { get; set; }

        public required ICollection<ComentarioDto> Comentarios { get; set; }
        public required ICollection<ColaboradorDto> Colaboradores { get; set; }
        public required ICollection<DonacionDto> Donaciones { get; set; }
        public required ICollection<ActualizacionDto> Actualizaciones { get; set; }

    }
}
