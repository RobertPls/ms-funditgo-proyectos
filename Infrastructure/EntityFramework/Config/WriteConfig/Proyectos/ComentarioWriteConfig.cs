using Domain.Model.Proyectos;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Proyectos
{
    public class ComentarioWriteConfig : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {

            var comentarioConverter = new ValueConverter<ComentarioValue, string>(
            comentarioValue => comentarioValue.Comentario,
            stringValue => new ComentarioValue(stringValue)
            );

            builder.ToTable("Comentario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UsuarioId).HasColumnName("usuarioId");
            builder.Property(x => x.Texto).HasColumnName("texto").HasConversion(comentarioConverter);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
