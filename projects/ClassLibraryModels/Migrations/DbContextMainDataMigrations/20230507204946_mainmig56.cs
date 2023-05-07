using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig56 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Pos_Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaidAt",
                table: "Pos_Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pos_MethodOfPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_MethodOfPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pos_OrderPayment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MethodOfPaymentId = table.Column<int>(type: "int", nullable: false),
                    pos_MethodOfPaymentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pos_OrderPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_pos_MethodOfPaymentId",
                        column: x => x.pos_MethodOfPaymentId,
                        principalTable: "Pos_MethodOfPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pos_OrderPayment_Pos_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Pos_Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pos_OrderPayment_OrderId",
                table: "Pos_OrderPayment",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pos_OrderPayment_pos_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "pos_MethodOfPaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pos_OrderPayment");

            migrationBuilder.DropTable(
                name: "Pos_MethodOfPayment");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "Pos_Orders");

            migrationBuilder.DropColumn(
                name: "PaidAt",
                table: "Pos_Orders");
        }
    }
}
