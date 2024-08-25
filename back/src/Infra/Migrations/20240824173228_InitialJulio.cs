using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialJulio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tipos_usuario",
                columns: table => new
                {
                    id_tipousuario = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    desc = table.Column<string>(type: "text", nullable: false),
                    origem = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_usuario", x => x.id_tipousuario);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id_usu = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_usu = table.Column<string>(type: "text", nullable: false),
                    matr_usu = table.Column<string>(type: "text", nullable: true),
                    data_nasc = table.Column<DateOnly>(type: "date", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    id_tipousuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id_usu);
                    table.ForeignKey(
                        name: "FK_usuarios_tipos_usuario_id_tipousuario",
                        column: x => x.id_tipousuario,
                        principalTable: "tipos_usuario",
                        principalColumn: "id_tipousuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_tipousuario",
                table: "usuarios",
                column: "id_tipousuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "tipos_usuario");
        }
    }
}