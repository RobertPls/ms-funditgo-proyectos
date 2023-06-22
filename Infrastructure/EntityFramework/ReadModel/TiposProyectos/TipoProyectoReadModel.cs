using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.TiposProyectos
{
    internal class TipoProyectoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
