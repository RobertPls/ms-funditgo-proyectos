using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class ComentarioReadConfig : IEntityTypeConfiguration<ComentarioReadModel>
    {
        public void Configure(EntityTypeBuilder<ComentarioReadModel> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Texto)
                .HasColumnName("texto");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("usuarioId");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.ProyectoId)
               .HasColumnName("proyectoId");
        }
    }
}
