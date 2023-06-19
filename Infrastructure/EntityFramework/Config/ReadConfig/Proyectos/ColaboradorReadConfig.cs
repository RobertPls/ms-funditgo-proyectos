using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class ColaboradorReadConfig : IEntityTypeConfiguration<ColaboradorReadModel>
    {
        public void Configure(EntityTypeBuilder<ColaboradorReadModel> builder)
        {
            builder.ToTable("Colaborador");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

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
