using Domain.Model.Proyectos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Config.WriteConfig.Proyectos
{
    public class ColaboradorWriteConfig : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaborador");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UsuarioId)
              .HasColumnName("usuarioId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
