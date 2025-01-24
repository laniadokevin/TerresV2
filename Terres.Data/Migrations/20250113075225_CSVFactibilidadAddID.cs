using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Terres.Data.Migrations
{
    /// <inheritdoc />
    public partial class CSVFactibilidadAddID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CSVFactibilidad",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CSVFactibilidad",
                table: "CSVFactibilidad",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CSVFactibilidad",
                table: "CSVFactibilidad");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CSVFactibilidad");
        }
    }
}
