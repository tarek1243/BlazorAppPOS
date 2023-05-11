using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig70 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Products_Pos_Companies_CompanyId",
                table: "Pos_Products");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Pos_Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Pos_Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Products_Pos_Companies_CompanyId",
                table: "Pos_Products",
                column: "CompanyId",
                principalTable: "Pos_Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Products_Pos_Companies_CompanyId",
                table: "Pos_Products");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Pos_Products");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Pos_Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Products_Pos_Companies_CompanyId",
                table: "Pos_Products",
                column: "CompanyId",
                principalTable: "Pos_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
