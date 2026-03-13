using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestaoOscAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false),
                    Perfil = table.Column<int>(type: "integer", nullable: false),
                    Setor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oscs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Equipamento = table.Column<string>(type: "text", nullable: false),
                    DataEmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EmitenteId = table.Column<int>(type: "integer", nullable: false),
                    EmitenteNome = table.Column<string>(type: "text", nullable: false),
                    EmitenteSetor = table.Column<string>(type: "text", nullable: false),
                    GerenteQualidadeId = table.Column<int>(type: "integer", nullable: true),
                    GerenteEngenhariaId = table.Column<int>(type: "integer", nullable: true),
                    GerenteProducaoId = table.Column<int>(type: "integer", nullable: true),
                    QualidadeAssinou = table.Column<bool>(type: "boolean", nullable: false),
                    EngenhariaAssinou = table.Column<bool>(type: "boolean", nullable: false),
                    ProducaoAssinou = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oscs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oscs_Usuarios_GerenteEngenhariaId",
                        column: x => x.GerenteEngenhariaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Oscs_Usuarios_GerenteProducaoId",
                        column: x => x.GerenteProducaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Oscs_Usuarios_GerenteQualidadeId",
                        column: x => x.GerenteQualidadeId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oscs_GerenteEngenhariaId",
                table: "Oscs",
                column: "GerenteEngenhariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oscs_GerenteProducaoId",
                table: "Oscs",
                column: "GerenteProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Oscs_GerenteQualidadeId",
                table: "Oscs",
                column: "GerenteQualidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oscs");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
