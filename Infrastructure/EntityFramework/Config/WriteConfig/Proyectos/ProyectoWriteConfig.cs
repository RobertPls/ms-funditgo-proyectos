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

            builder.Property(x => x.FechaCreacion).HasColumnName("fechaCreacion");

            builder.Property(x => x.Estado).HasColumnName("estado");

            builder.Property(x => x.CreadorId).HasColumnName("creadorId");

            builder.Property(x => x.TipoProyectoId).HasColumnName("tipoProyectoId");

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



            var donacionEsperadaConverter = new ValueConverter<DonacionValue, decimal>(
                donacionEsperadaValue => donacionEsperadaValue.Value,
                decimalValue => new DonacionValue(decimalValue)
            );
            builder.Property(x => x.DonacionEsperada).HasColumnName("DonacionEsperada").HasConversion(donacionEsperadaConverter);

            var donacionRecibidaConverter = new ValueConverter<PrecioValue, decimal>(
                donacionRecibidaValue => donacionRecibidaValue.Value,
                decimalValue => new PrecioValue(decimalValue)
            );
            builder.Property(x => x.DonacionRecibida).HasColumnName("DonacionRecibida").HasConversion(donacionRecibidaConverter);



            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}

