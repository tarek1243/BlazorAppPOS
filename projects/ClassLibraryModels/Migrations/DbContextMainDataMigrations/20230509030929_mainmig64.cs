using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig64 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Pos_Orders_WebApp1User_userId",
            //    table: "Pos_Orders");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_WebApp1User",
            //    table: "WebApp1User");

            //migrationBuilder.RenameTable(
            //    name: "WebApp1User",
            //    newName: "AspNetUsers");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_AspNetUsers",
            //    table: "AspNetUsers",
            //    column: "Id");

            //////migrationBuilder.AddForeignKey(
            //////    name: "FK_Pos_Orders_AspNetUsers_userId",
            //////    table: "Pos_Orders",
            //////    column: "userId",
            //////    principalTable: "AspNetUsers",
            //////    principalColumn: "Id");

            migrationBuilder.AddForeignKey(
             name: "FK_Pos_Orders_AspNetUsers_userId",
             table: "Pos_Orders",
             column: "userId",
             principalTable: "AspNetUsers",
             principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Orders_AspNetUsers_userId",
                table: "Pos_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "WebApp1User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WebApp1User",
                table: "WebApp1User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Orders_WebApp1User_userId",
                table: "Pos_Orders",
                column: "userId",
                principalTable: "WebApp1User",
                principalColumn: "Id");
        }
    }
}
