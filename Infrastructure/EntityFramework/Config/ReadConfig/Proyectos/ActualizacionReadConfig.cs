using Infrastructure.EntityFramework.ReadModel.Proyectos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFramework.Config.ReadConfig.Proyectos
{
    internal class ActualizacionReadConfig : IEntityTypeConfiguration<ActualizacionReadModel>
    {
        public void Configure(EntityTypeBuilder<ActualizacionReadModel> builder)
        {
            builder.ToTable("Actualizacion");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha");

            builder.Property(x => x.Descripcion)
                .HasColumnName("Descripcion");

            builder.Property(x => x.UsuarioId)
                .HasColumnName("usuarioId");

            builder.HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(x => x.ProyectoId)
               .HasColumnName("proyectoId");
        }
    }
}
