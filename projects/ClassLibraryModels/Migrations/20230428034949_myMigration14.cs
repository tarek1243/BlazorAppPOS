using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations
{
    /// <inheritdoc />
    public partial class myMigration14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VAT_number",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VAT_number",
                table: "AspNetUsers");
        }
    }
}
