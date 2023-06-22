using Domain.Model.Proyectos;
using Domain.Model.TiposProyectos;
using Domain.Model.Usuarios;
using Infrastructure.EntityFramework.Config.WriteConfig.Proyectos;
using Infrastructure.EntityFramework.Config.WriteConfig.TiposProyectos;
using Infrastructure.EntityFramework.Config.WriteConfig.Usuarios;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Usuario> Usuario{ get; set; }
        public virtual DbSet<Actualizacion> Actualizacion { get; set; }
        public virtual DbSet<Donacion> Donacion { get; set; }
        public virtual DbSet<TipoProyecto> TipoProyecto { get; set; }



        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProyectoWriteConfig());
            modelBuilder.ApplyConfiguration(new ComentarioWriteConfig());
            modelBuilder.ApplyConfiguration(new ColaboradorWriteConfig());
            modelBuilder.ApplyConfiguration(new UsuarioWriteConfig());
            modelBuilder.ApplyConfiguration(new ActualizacionWriteConfig());
            modelBuilder.ApplyConfiguration(new DonacionWriteConfig());
            modelBuilder.ApplyConfiguration(new TipoProyectoWriteConfig());

        }
    }
}
