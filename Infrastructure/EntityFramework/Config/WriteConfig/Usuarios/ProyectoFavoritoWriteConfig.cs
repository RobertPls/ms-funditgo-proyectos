using Domain.Model.Usuarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Usuarios
{
    public class ProyectoFavoritoWriteConfig : IEntityTypeConfiguration<ProyectoFavorito>
    {
        public void Configure(EntityTypeBuilder<ProyectoFavorito> builder)
        {
            builder.ToTable("ProyectoFavorito");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProyectoId).HasColumnName("proyectoId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
