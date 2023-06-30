using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class DonacionReadConfig : IEntityTypeConfiguration<DonacionReadModel>
    {
        public void Configure(EntityTypeBuilder<DonacionReadModel> builder)
        {
            builder.ToTable("Donacion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Estado).HasColumnName("estado");
            builder.Property(x => x.Monto).HasColumnName("monto").HasPrecision(14, 2);
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");

            builder.Property(x => x.ProyectoId).HasColumnName("proyectoId");
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey(x => x.UsuarioId);
        }
    }
}
