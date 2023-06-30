using Application.Dto.TiposProyectos;
using Application.Dto.Usuarios;

namespace Application.Dto.Proyectos
{
    public class ProyectoDto
    {
        public Guid Id { get; set; }

        public UsuarioSimpleDto Creador { get; set; }

        public TipoProyectoDto Tipo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Estado { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Historia { get; set; }
        
        public string CompromisoAmbiental { get; set; }

        public decimal DonacionEsperada { get; set; }

        public decimal DonacionRecibida { get; set; }

        public decimal DonacionMinima { get; set; }

        public ICollection<ComentarioDto> Comentarios { get; set; }
        public ICollection<ColaboradorDto> Colaboradores { get; set; }
        public ICollection<DonacionDto> Donaciones { get; set; }
        public ICollection<ActualizacionDto> Actualizaciones { get; set; }

    }
}
