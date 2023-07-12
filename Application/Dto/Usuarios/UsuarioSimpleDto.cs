using Application.Dto.Proyectos;

namespace Application.Dto.Usuarios
{
    public class UsuarioSimpleDto
    {
        public Guid Id { get; set; }

        public required string NombreCompleto { get; set; }

        public required string UserName { get; set; }

    }
}
