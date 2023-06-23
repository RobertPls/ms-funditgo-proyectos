namespace Application.Dto.Proyectos
{
    public class DonacionDto
    {
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string Estado { get; set; }

    }
}
