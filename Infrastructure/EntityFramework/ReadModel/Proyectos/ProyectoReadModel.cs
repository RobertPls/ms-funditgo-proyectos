using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.EntityFramework.ReadModel.Proyectos
{
    internal class ProyectoReadModel
    {
        [Key]
        public Guid Id { get; set; }

        public UsuarioReadModel Creador { get; set; }
        public Guid CreadorId { get; set; }

        public TipoProyectoReadModel TipoProyecto { get; set; }
        public Guid TipoProyectoId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Estado { get; set; }

        public string Titulo { get; set; }

        public string Descripcion { get; set; }

        public string Historia { get; set; }

        public string CompromisoAmbiental { get; set; }

        public decimal DonacionEsperada { get; set; }

        public decimal DonacionRecibida { get; set; }

        public decimal DonacionMinima { get; set; }

        public ICollection<ColaboradorReadModel> Colaboradores { get; set; }

        public ICollection<ComentarioReadModel> Comentarios { get; set; }

        public ICollection<ActualizacionReadModel> Actualizaciones { get; set; }

        public ICollection<DonacionReadModel> Donaciones { get; set; }

    }
}
