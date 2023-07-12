using Domain.Model.Usuarios;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Usuarios
{
    internal class UsuarioWriteConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            var nombrePersonaConverter = new ValueConverter<NombrePersonaValue, string>(
                nombrePersonaValue => nombrePersonaValue.Nombre,
                stringValue => new NombrePersonaValue(stringValue)
            );

            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NombreCompleto).HasColumnName("nombreCompleto").HasConversion(nombrePersonaConverter);
            builder.Property(x => x.UserName).HasColumnName("userName");

            builder.Ignore(x => x.DomainEvents);
            builder.Ignore("_domainEvents");
        }
    }
}

