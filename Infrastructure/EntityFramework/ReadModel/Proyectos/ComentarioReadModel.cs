using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class ComentarioReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Texto { get; set; }
        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public ProyectoReadModel Proyecto{ get; set; }
        public Guid ProyectoId { get; set; }
    }
}
