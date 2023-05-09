using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig61 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Orders_WebApp1User_userId",
                table: "Pos_Orders");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Pos_Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Orders_WebApp1User_userId",
                table: "Pos_Orders",
                column: "userId",
                principalTable: "WebApp1User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Orders_WebApp1User_userId",
                table: "Pos_Orders");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Pos_Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Orders_WebApp1User_userId",
                table: "Pos_Orders",
                column: "userId",
                principalTable: "WebApp1User",
                principalColumn: "Id");
        }
    }
}
