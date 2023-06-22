using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class DonacionReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public decimal Monto { get; set; }
        public UsuarioReadModel Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public ProyectoReadModel Proyecto { get; set; }
        public Guid ProyectoId { get; set; }
    }
}
