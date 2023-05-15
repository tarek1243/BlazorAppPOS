using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig77 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pos_Site",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pos_Warehouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Site_Id = table.Column<int>(type: "int", nullable: false),
                    siteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pos_Warehouse_Pos_Site_siteId",
                        column: x => x.siteId,
                        principalTable: "Pos_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pos_InventoryTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_InventoryTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pos_InventoryTransaction_Pos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Pos_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pos_InventoryTransaction_Pos_Site_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Pos_Site",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pos_InventoryTransaction_Pos_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Pos_Warehouse",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pos_InventoryTransaction_ProductId",
                table: "Pos_InventoryTransaction",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_InventoryTransaction_SiteId",
                table: "Pos_InventoryTransaction",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_InventoryTransaction_WarehouseId",
                table: "Pos_InventoryTransaction",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_Warehouse_siteId",
                table: "Pos_Warehouse",
                column: "siteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pos_InventoryTransaction");

            migrationBuilder.DropTable(
                name: "Pos_Warehouse");

            migrationBuilder.DropTable(
                name: "Pos_Site");
        }
    }
}
