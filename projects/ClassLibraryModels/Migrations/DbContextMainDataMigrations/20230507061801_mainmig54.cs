using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig54 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pos_CartItems");

            migrationBuilder.AddColumn<int>(
                name: "LoyaltyPoints",
                table: "Pos_Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pos_OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pos_OrderLines_Pos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Pos_Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pos_OrderLines_Pos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Pos_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pos_OrderLines_OrderId",
                table: "Pos_OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_OrderLines_ProductId",
                table: "Pos_OrderLines",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pos_OrderLines");

            migrationBuilder.DropColumn(
                name: "LoyaltyPoints",
                table: "Pos_Customers");

            migrationBuilder.CreateTable(
                name: "Pos_CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pos_CartItems_Pos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Pos_Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pos_CartItems_Pos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Pos_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pos_CartItems_OrderId",
                table: "Pos_CartItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_CartItems_ProductId",
                table: "Pos_CartItems",
                column: "ProductId");
        }
    }
}
