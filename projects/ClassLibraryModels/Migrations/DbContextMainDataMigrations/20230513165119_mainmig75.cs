using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig75 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Pos_Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptFooter1",
                table: "Pos_Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptFooter2",
                table: "Pos_Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptFooter3",
                table: "Pos_Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptHeader1",
                table: "Pos_Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptHeader2",
                table: "Pos_Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiptHeader3",
                table: "Pos_Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Pos_Products");

            migrationBuilder.DropColumn(
                name: "ReceiptFooter1",
                table: "Pos_Companies");

            migrationBuilder.DropColumn(
                name: "ReceiptFooter2",
                table: "Pos_Companies");

            migrationBuilder.DropColumn(
                name: "ReceiptFooter3",
                table: "Pos_Companies");

            migrationBuilder.DropColumn(
                name: "ReceiptHeader1",
                table: "Pos_Companies");

            migrationBuilder.DropColumn(
                name: "ReceiptHeader2",
                table: "Pos_Companies");

            migrationBuilder.DropColumn(
                name: "ReceiptHeader3",
                table: "Pos_Companies");
        }
    }
}
