using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAspNet.Migrations
{
    /// <inheritdoc />
    public partial class CriandoAsFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_storeId",
                table: "products",
                column: "storeId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_storeId",
                table: "categories",
                column: "storeId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_stores_storeId",
                table: "categories",
                column: "storeId",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_stores_storeId",
                table: "products",
                column: "storeId",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_stores_storeId",
                table: "categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_stores_storeId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_storeId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_categories_storeId",
                table: "categories");
        }
    }
}
