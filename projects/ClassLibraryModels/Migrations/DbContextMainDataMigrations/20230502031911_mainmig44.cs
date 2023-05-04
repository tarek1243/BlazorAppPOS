using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowOrders",
                table: "Pos_Shifts",
                newName: "ShowLines");

            migrationBuilder.AddColumn<bool>(
                name: "ShowLines",
                table: "Pos_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShowLines",
                table: "Pos_Orders");

            migrationBuilder.RenameColumn(
                name: "ShowLines",
                table: "Pos_Shifts",
                newName: "ShowOrders");
        }
    }
}
