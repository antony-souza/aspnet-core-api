using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAspNet.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoNomeDaTabelaStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_Store_storeId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Store",
                table: "Store");

            migrationBuilder.RenameTable(
                name: "Store",
                newName: "stores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stores",
                table: "stores",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_stores_storeId",
                table: "users",
                column: "storeId",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_stores_storeId",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stores",
                table: "stores");

            migrationBuilder.RenameTable(
                name: "stores",
                newName: "Store");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Store",
                table: "Store",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_Store_storeId",
                table: "users",
                column: "storeId",
                principalTable: "Store",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
