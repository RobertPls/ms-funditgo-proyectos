using Infrastructure.EntityFramework.ReadModel.Usuarios;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class UsuarioReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public ICollection<ProyectoFavoritoReadModel> ProyectosFavoritos { get; set; }

    }
}
