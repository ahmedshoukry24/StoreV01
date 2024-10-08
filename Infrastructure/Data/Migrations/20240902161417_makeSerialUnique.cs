using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class makeSerialUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Variations_Serial",
                table: "Variations",
                column: "Serial",
                unique: true,
                filter: "[Serial] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_Serial",
                table: "Stores",
                column: "Serial",
                unique: true,
                filter: "[Serial] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_Serial",
                table: "Branches",
                column: "Serial",
                unique: true,
                filter: "[Serial] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Variations_Serial",
                table: "Variations");

            migrationBuilder.DropIndex(
                name: "IX_Stores_Serial",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Branches_Serial",
                table: "Branches");
        }
    }
}
