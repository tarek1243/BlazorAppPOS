using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig52 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_Date",
                table: "Pos_Shifts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_Date",
                table: "Pos_Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Pos_Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_Date",
                table: "Pos_Customers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_Date",
                table: "Pos_Shifts");

            migrationBuilder.DropColumn(
                name: "created_Date",
                table: "Pos_Orders");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Pos_Customers");

            migrationBuilder.DropColumn(
                name: "created_Date",
                table: "Pos_Customers");
        }
    }
}
