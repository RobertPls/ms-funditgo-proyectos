using Application.Dto.Usuarios;

namespace Application.Dto.Proyectos
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        public required string NombreCompleto { get; set; }
        public required string UserName { get; set; }
        public ICollection<ProyectoFavoritoDto> ProyectosFavoritos { get; set; }

    }
}
