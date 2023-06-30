using Application.Dto.Usuarios;

namespace Application.Dto.Proyectos
{
    public class ActualizacionDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public UsuarioSimpleDto Usuario { get; set; }
    }
}
