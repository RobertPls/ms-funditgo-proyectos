using Application.Dto.Usuarios;

namespace Application.Dto.Proyectos
{
    public class ColaboradorDto
    {
        public Guid Id { get; set; }
        public UsuarioSimpleDto Usuario { get; set; }
    }
}
