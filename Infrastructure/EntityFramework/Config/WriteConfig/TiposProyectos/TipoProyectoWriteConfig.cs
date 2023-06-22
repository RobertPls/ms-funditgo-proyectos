using Domain.Model.TiposProyectos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.TiposProyectos
{
    internal class TipoProyectoWriteConfig : IEntityTypeConfiguration<TipoProyecto>
    {
        public void Configure(EntityTypeBuilder<TipoProyecto> builder)
        {
            builder.ToTable("TipoProyecto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre).HasColumnName("nombre");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}
