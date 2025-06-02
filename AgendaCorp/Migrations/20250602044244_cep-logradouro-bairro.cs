using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaCorp.Migrations
{
    /// <inheritdoc />
    public partial class ceplogradourobairro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Eventos");
        }
    }
}
