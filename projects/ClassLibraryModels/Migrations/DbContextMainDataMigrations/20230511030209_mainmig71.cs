using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig71 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSupplementary",
                table: "Pos_OrderLines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSupplementary",
                table: "Pos_OrderLines");
        }
    }
}
