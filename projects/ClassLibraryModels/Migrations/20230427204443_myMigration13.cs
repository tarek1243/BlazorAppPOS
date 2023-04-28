using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations
{
    /// <inheritdoc />
    public partial class myMigration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "logo",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "logo",
                table: "AspNetUsers");
        }
    }
}
