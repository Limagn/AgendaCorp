using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaCorp.Migrations
{
    /// <inheritdoc />
    public partial class ufevento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Eventos");
        }
    }
}
