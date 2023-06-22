using Domain.Model.Proyectos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Proyectos
{
    public class ActualizacionWriteConfig : IEntityTypeConfiguration<Actualizacion>
    {
        public void Configure(EntityTypeBuilder<Actualizacion> builder)
        {
            builder.ToTable("Actualizacion");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("usuarioId");

            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
                descripcionValue => descripcionValue.Descripcion,
                stringValue => new DescripcionValue(stringValue)
            );
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
