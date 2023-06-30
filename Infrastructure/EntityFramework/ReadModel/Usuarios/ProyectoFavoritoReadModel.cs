using Infrastructure.EntityFramework.ReadModel.Proyectos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Usuarios
{
    internal class ProyectoFavoritoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public ProyectoReadModel Proyecto { get; set; }
        public Guid ProyectoId { get; set; }

        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
