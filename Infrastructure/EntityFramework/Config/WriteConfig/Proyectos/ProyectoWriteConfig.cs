using Domain.Model.Proyectos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Proyectos
{
    internal class ProyectoWriteConfig : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.ToTable("Proyecto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreadorId).HasColumnName("creadorId");

            var tituloConverter = new ValueConverter<TituloValue, string>(
                tituloValue => tituloValue.Titulo,
                stringValue => new TituloValue(stringValue)
            );
            builder.Property(x => x.Titulo).HasColumnName("titulo").HasConversion(tituloConverter);

            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
                descripcionValue => descripcionValue.Descripcion,
                stringValue => new DescripcionValue(stringValue)
            );
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);



            var montoConverter = new ValueConverter<PrecioValue, decimal>(
                montoValue => montoValue.Value,
                decimalValue => new PrecioValue(decimalValue)
            );
            builder.Property(x => x.Monto).HasColumnName("monto").HasConversion(montoConverter);


            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}

