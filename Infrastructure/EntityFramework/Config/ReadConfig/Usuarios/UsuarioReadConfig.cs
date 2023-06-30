using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class UsuarioReadConfig : IEntityTypeConfiguration<UsuarioReadModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioReadModel> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.NombreCompleto).HasColumnName("nombreCompleto");

            builder.HasMany(x => x.ProyectosFavoritos).WithOne(x => x.Usuario).HasForeignKey(x => x.UsuarioId);
        }
    }
}
