using Application.Dto.Proyectos;

namespace Application.Dto.Usuarios
{
    public class ProyectoFavoritoDto
    {
        public Guid Id { get; set; }
        public ProyectoSimpleDto Proyecto { get; set; }
    }
}
