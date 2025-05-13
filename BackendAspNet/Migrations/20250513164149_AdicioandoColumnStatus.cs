using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAspNet.Migrations
{
    /// <inheritdoc />
    public partial class AdicioandoColumnStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paymentStatus",
                table: "orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentStatus",
                table: "orders");
        }
    }
}
