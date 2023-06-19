﻿// <auto-generated />
using System;
using Infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(ReadDbContext))]
    partial class ReadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ColaboradorReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ProyectoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("proyectoId");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Colaborador", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ComentarioReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ProyectoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("proyectoId");

                    b.Property<string>("Texto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("texto");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("usuarioId");

                    b.HasKey("Id");

                    b.HasIndex("ProyectoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentario", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ProyectoReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("CreadorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("creadorId");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<decimal>("Monto")
                        .HasPrecision(14, 2)
                        .HasColumnType("decimal(14,2)")
                        .HasColumnName("monto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.HasIndex("CreadorId");

                    b.ToTable("Proyecto", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.UsuarioReadModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nombreCompleto");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ColaboradorReadModel", b =>
                {
                    b.HasOne("Infrastructure.EntityFramework.ReadModel.Proyectos.ProyectoReadModel", "Proyecto")
                        .WithMany("Colaboradores")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EntityFramework.ReadModel.Proyectos.UsuarioReadModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ComentarioReadModel", b =>
                {
                    b.HasOne("Infrastructure.EntityFramework.ReadModel.Proyectos.ProyectoReadModel", "Proyecto")
                        .WithMany("Comentarios")
                        .HasForeignKey("ProyectoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EntityFramework.ReadModel.Proyectos.UsuarioReadModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proyecto");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ProyectoReadModel", b =>
                {
                    b.HasOne("Infrastructure.EntityFramework.ReadModel.Proyectos.UsuarioReadModel", "Creador")
                        .WithMany()
                        .HasForeignKey("CreadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creador");
                });

            modelBuilder.Entity("Infrastructure.EntityFramework.ReadModel.Proyectos.ProyectoReadModel", b =>
                {
                    b.Navigation("Colaboradores");

                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
