using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig57 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_OrderLines_Pos_Products_ProductId",
                table: "Pos_OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_pos_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.DropIndex(
                name: "IX_Pos_OrderPayment_pos_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.DropColumn(
                name: "pos_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Pos_OrderLines",
                newName: "product_id");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_OrderLines_ProductId",
                table: "Pos_OrderLines",
                newName: "IX_Pos_OrderLines_product_id");

            migrationBuilder.AddColumn<decimal>(
                name: "Paid_Total_With_VAT",
                table: "Pos_Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Pos_MethodOfPayment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pos_OrderPayment_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "MethodOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_OrderLines_Pos_Products_product_id",
                table: "Pos_OrderLines",
                column: "product_id",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "MethodOfPaymentId",
                principalTable: "Pos_MethodOfPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_OrderLines_Pos_Products_product_id",
                table: "Pos_OrderLines");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.DropIndex(
                name: "IX_Pos_OrderPayment_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.DropColumn(
                name: "Paid_Total_With_VAT",
                table: "Pos_Orders");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Pos_MethodOfPayment");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Pos_OrderLines",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_OrderLines_product_id",
                table: "Pos_OrderLines",
                newName: "IX_Pos_OrderLines_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "pos_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pos_OrderPayment_pos_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "pos_MethodOfPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_OrderLines_Pos_Products_ProductId",
                table: "Pos_OrderLines",
                column: "ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_pos_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "pos_MethodOfPaymentId",
                principalTable: "Pos_MethodOfPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
