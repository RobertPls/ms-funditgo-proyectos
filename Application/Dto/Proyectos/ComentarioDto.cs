namespace Application.Dto.Proyectos
{
    public class ComentarioDto
    {
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}
