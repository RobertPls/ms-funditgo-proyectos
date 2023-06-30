using Infrastructure.EntityFramework.ReadModel.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Usuarios
{
    internal class ProyectoFavoritoReadConfig : IEntityTypeConfiguration<ProyectoFavoritoReadModel>
    {
        public void Configure(EntityTypeBuilder<ProyectoFavoritoReadModel> builder)
        {
            builder.ToTable("ProyectoFavorito");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");

            builder.Property(x => x.ProyectoId).HasColumnName("proyectoId");
            builder.HasOne(x => x.Proyecto).WithMany().HasForeignKey(x => x.ProyectoId);
        }
    }
}
