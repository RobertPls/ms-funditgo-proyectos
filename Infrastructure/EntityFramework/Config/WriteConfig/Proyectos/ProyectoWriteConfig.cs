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

            var descripcionConverter = new ValueConverter<DescripcionValue, string>(
                descripcionValue => descripcionValue.Descripcion,
                stringValue => new DescripcionValue(stringValue)
            );
            var tituloConverter = new ValueConverter<TituloValue, string>(
                tituloValue => tituloValue.Titulo,
                stringValue => new TituloValue(stringValue)
            );
            var donacionRecibidaConverter = new ValueConverter<PrecioValue, decimal>(
                donacionRecibidaValue => donacionRecibidaValue.Value,
                decimalValue => new PrecioValue(decimalValue)
            );
            var donacionConverter = new ValueConverter<DonacionValue, decimal>(
                donacionValue => donacionValue.Value,
                decimalValue => new DonacionValue(decimalValue)
            );

            builder.ToTable("Proyecto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FechaCreacion).HasColumnName("fechaCreacion");
            builder.Property(x => x.Estado).HasColumnName("estado");
            builder.Property(x => x.CreadorId).HasColumnName("creadorId");
            builder.Property(x => x.TipoProyectoId).HasColumnName("tipoProyectoId");
            builder.Property(x => x.Titulo).HasColumnName("titulo").HasConversion(tituloConverter);
            builder.Property(x => x.Descripcion).HasColumnName("descripcion").HasConversion(descripcionConverter);
            builder.Property(x => x.Historia).HasColumnName("historia").HasConversion(descripcionConverter);
            builder.Property(x => x.CompromisoAmbiental).HasColumnName("compromisoAmbiental").HasConversion(descripcionConverter);
            builder.Property(x => x.DonacionEsperada).HasColumnName("donacionEsperada").HasConversion(donacionConverter);
            builder.Property(x => x.DonacionRecibida).HasColumnName("donacionRecibida").HasConversion(donacionRecibidaConverter);
            builder.Property(x => x.DonacionMinima).HasColumnName("donacionMinima").HasConversion(donacionConverter);

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}

