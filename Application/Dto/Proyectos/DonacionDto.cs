using Application.Dto.Usuarios;

namespace Application.Dto.Proyectos
{
    public class DonacionDto
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public UsuarioSimpleDto Usuario { get; set; }
        public string Estado { get; set; }

    }
}
