using Application.Dto.Usuarios;

namespace Application.Dto.Proyectos
{
    public class ComentarioDto
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public UsuarioSimpleDto Usuario { get; set; }
    }
}
