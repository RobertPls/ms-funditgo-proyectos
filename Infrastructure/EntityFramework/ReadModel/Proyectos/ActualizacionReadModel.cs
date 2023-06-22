using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class ActualizacionReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public ProyectoReadModel Proyecto { get; set; }
        public Guid ProyectoId { get; set; }
    }
}
