using Infrastructure.EntityFramework.Config.ReadConfig.Proyectos;
using Infrastructure.EntityFramework.Config.ReadConfig.TiposProyectos;
using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Infrastructure.EntityFramework.ReadModel.TiposProyectos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Context
{
    internal class ReadDbContext : DbContext
    {
        public virtual DbSet<ProyectoReadModel> Proyecto { get; set; }
        public virtual DbSet<ColaboradorReadModel> Colaborador{ get; set; }
        public virtual DbSet<ComentarioReadModel> Comentario { get; set; }
        public virtual DbSet<UsuarioReadModel> Usuario{ get; set; }
        public virtual DbSet<ActualizacionReadModel> Actualizacion { get; set; }
        public virtual DbSet<DonacionReadModel> Donacion { get; set; }
        public virtual DbSet<TipoProyectoReadModel> TipoProyecto { get; set; }




        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProyectoReadConfig());
            modelBuilder.ApplyConfiguration(new ComentarioReadConfig());
            modelBuilder.ApplyConfiguration(new ColaboradorReadConfig());
            modelBuilder.ApplyConfiguration(new UsuarioReadConfig());
            modelBuilder.ApplyConfiguration(new ActualizacionReadConfig());
            modelBuilder.ApplyConfiguration(new DonacionReadConfig());
            modelBuilder.ApplyConfiguration(new TipoProyectoReadConfig());


        }
    }
}
