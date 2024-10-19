using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships_between_branch_product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Branches_BranchId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Stores_StoreId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Variations_Branches_BranchId",
                table: "Variations");

            migrationBuilder.DropTable(
                name: "BranchProducts");

            migrationBuilder.DropIndex(
                name: "IX_Variations_BranchId",
                table: "Variations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Variations");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameIndex(
                name: "IX_Media_StoreId",
                table: "Medias",
                newName: "IX_Medias_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Media_BranchId",
                table: "Medias",
                newName: "IX_Medias_BranchId");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BranchId",
                table: "Products",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Branches_BranchId",
                table: "Medias",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Stores_StoreId",
                table: "Medias",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Branches_BranchId",
                table: "Products",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Branches_BranchId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Stores_StoreId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Branches_BranchId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_BranchId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_StoreId",
                table: "Media",
                newName: "IX_Media_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_BranchId",
                table: "Media",
                newName: "IX_Media_BranchId");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Variations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BranchProducts",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchProducts", x => new { x.ProductId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_BranchProducts_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Variations_BranchId",
                table: "Variations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchProducts_BranchId",
                table: "BranchProducts",
                column: "BranchId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Variations_Branches_BranchId",
                table: "Variations",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
