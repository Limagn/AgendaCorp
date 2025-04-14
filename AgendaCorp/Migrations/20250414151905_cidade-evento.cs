using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaCorp.Migrations
{
    /// <inheritdoc />
    public partial class cidadeevento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palestrantes_Eventos_EventoId",
                table: "Palestrantes");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Palestrantes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Palestrantes_Eventos_EventoId",
                table: "Palestrantes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Palestrantes_Eventos_EventoId",
                table: "Palestrantes");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Eventos");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Palestrantes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Palestrantes_Eventos_EventoId",
                table: "Palestrantes",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "EventoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
