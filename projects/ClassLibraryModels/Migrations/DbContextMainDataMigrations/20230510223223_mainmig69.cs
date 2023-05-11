using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig69 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "Pos_RelatedProducts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "Pos_RelatedProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
