using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventorySystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ApplicationUser_AdminID",
                table: "Stocks");

            migrationBuilder.AlterColumn<string>(
                name: "AdminID",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ApplicationUser_AdminID",
                table: "Stocks",
                column: "AdminID",
                principalTable: "ApplicationUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_ApplicationUser_AdminID",
                table: "Stocks");

            migrationBuilder.AlterColumn<string>(
                name: "AdminID",
                table: "Stocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_ApplicationUser_AdminID",
                table: "Stocks",
                column: "AdminID",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
