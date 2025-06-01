using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaCorp.Migrations
{
    /// <inheritdoc />
    public partial class palestranteEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palestrantes_Eventos_EventoId",
                table: "Palestrantes");

            migrationBuilder.DropIndex(
                name: "IX_Palestrantes_EventoId",
                table: "Palestrantes");

            migrationBuilder.DropColumn(
                name: "EventoId",
                table: "Palestrantes");

            migrationBuilder.CreateTable(
                name: "PalestranteEventos",
                columns: table => new
                {
                    PalestranteId = table.Column<int>(type: "int", nullable: false),
                    EventoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalestranteEventos", x => new { x.PalestranteId, x.EventoId });
                    table.ForeignKey(
                        name: "FK_PalestranteEventos_Eventos_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Eventos",
                        principalColumn: "EventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PalestranteEventos_Palestrantes_PalestranteId",
                        column: x => x.PalestranteId,
                        principalTable: "Palestrantes",
                        principalColumn: "PalestranteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PalestranteEventos_EventoId",
                table: "PalestranteEventos",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PalestranteEventos");

            migrationBuilder.AddColumn<int>(
                name: "EventoId",
                table: "Palestrantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Palestrantes_EventoId",
                table: "Palestrantes",
                column: "EventoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Palestrantes_Eventos_EventoId",
                table: "Palestrantes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId");
        }
    }
}
