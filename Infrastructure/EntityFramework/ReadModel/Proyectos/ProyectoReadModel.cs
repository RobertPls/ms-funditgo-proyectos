using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class ProyectoReadModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public decimal Monto { get; set; }

        public UsuarioReadModel Creador { get; set; }
        public Guid CreadorId { get; set; }

        public ICollection<ColaboradorReadModel> Colaboradores { get; set; }


        public ICollection<ComentarioReadModel> Comentarios { get; set; }
    }
}
