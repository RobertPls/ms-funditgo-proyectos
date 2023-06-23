using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class EstructuraInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoProyecto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProyecto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    creadorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tipoProyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    donacionEsperada = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    donacionRecibida = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Proyecto_TipoProyecto_tipoProyectoId",
                        column: x => x.tipoProyectoId,
                        principalTable: "TipoProyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyecto_Usuario_creadorId",
                        column: x => x.creadorId,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actualizacion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actualizacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Actualizacion_Proyecto_proyectoId",
                        column: x => x.proyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actualizacion_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.id);
                    table.ForeignKey(
                        name: "FK_Colaborador_Proyecto_proyectoId",
                        column: x => x.proyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colaborador_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comentario_Proyecto_proyectoId",
                        column: x => x.proyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentario_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donacion",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    monto = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    usuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    proyectoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donacion", x => x.id);
                    table.ForeignKey(
                        name: "FK_Donacion_Proyecto_proyectoId",
                        column: x => x.proyectoId,
                        principalTable: "Proyecto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donacion_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actualizacion_proyectoId",
                table: "Actualizacion",
                column: "proyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Actualizacion_usuarioId",
                table: "Actualizacion",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_proyectoId",
                table: "Colaborador",
                column: "proyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_usuarioId",
                table: "Colaborador",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_proyectoId",
                table: "Comentario",
                column: "proyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_usuarioId",
                table: "Comentario",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacion_proyectoId",
                table: "Donacion",
                column: "proyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Donacion_usuarioId",
                table: "Donacion",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_creadorId",
                table: "Proyecto",
                column: "creadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_tipoProyectoId",
                table: "Proyecto",
                column: "tipoProyectoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actualizacion");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Donacion");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "TipoProyecto");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
