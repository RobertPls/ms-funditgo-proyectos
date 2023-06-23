using Application.Dto.TiposProyectos;

namespace Application.Dto.Proyectos
{
    public class ProyectoDto
    {
        public Guid Id { get; set; }

        public UsuarioDto Creador { get; set; }

        public TipoProyectoDto Tipo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Estado { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public decimal DonacionEsperada { get; set; }

        public decimal DonacionRecibida { get; set; }

        public ICollection<ComentarioDto> Comentarios { get; set; }
        public ICollection<ColaboradorDto> Colaboradores { get; set; }
        public ICollection<DonacionDto> Donaciones { get; set; }
        public ICollection<ActualizacionDto> Actualizaciones { get; set; }

    }
}
