using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class ProyectoReadConfig : IEntityTypeConfiguration<ProyectoReadModel>
    {
        public void Configure(EntityTypeBuilder<ProyectoReadModel> builder)
        {
            builder.ToTable("Proyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Titulo)
                .HasColumnName("titulo");

            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion");

            builder.Property(x => x.Monto)
                .HasColumnName("monto")
                .HasPrecision(14, 2);


            builder.Property(x => x.CreadorId)
                .HasColumnName("creadorId");

            builder.HasOne(x => x.Creador)
                .WithMany()
                .HasForeignKey(x => x.CreadorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Comentarios)
                .WithOne(x => x.Proyecto)
                .HasForeignKey(x => x.ProyectoId);

            builder.HasMany(x => x.Colaboradores)
                .WithOne(x => x.Proyecto)
                .HasForeignKey(x => x.ProyectoId);
        }
    }
}
