using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BranchMedia_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Stores_StoreId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_StoreId",
                table: "Media");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_BranchId",
                table: "Media",
                column: "BranchId",
                unique: true,
                filter: "[BranchId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Media_StoreId",
                table: "Media",
                column: "StoreId",
                unique: true,
                filter: "[StoreId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Branches_BranchId",
                table: "Media",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Stores_StoreId",
                table: "Media",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Branches_BranchId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Stores_StoreId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_BranchId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_StoreId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Media");

            migrationBuilder.AlterColumn<Guid>(
                name: "StoreId",
                table: "Media",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_StoreId",
                table: "Media",
                column: "StoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Stores_StoreId",
                table: "Media",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
