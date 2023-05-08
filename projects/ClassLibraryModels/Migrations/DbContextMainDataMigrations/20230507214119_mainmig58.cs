using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig58 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_MethodOfPayment",
                table: "Pos_MethodOfPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyInvoiceNumbers",
                table: "CompanyInvoiceNumbers");

            migrationBuilder.RenameTable(
                name: "Pos_MethodOfPayment",
                newName: "Pos_MethodOfPayments");

            migrationBuilder.RenameTable(
                name: "CompanyInvoiceNumbers",
                newName: "Pos_CompanyInvoiceNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_MethodOfPayments",
                table: "Pos_MethodOfPayments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_CompanyInvoiceNumbers",
                table: "Pos_CompanyInvoiceNumbers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayments_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "MethodOfPaymentId",
                principalTable: "Pos_MethodOfPayments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayments_MethodOfPaymentId",
                table: "Pos_OrderPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_MethodOfPayments",
                table: "Pos_MethodOfPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_CompanyInvoiceNumbers",
                table: "Pos_CompanyInvoiceNumbers");

            migrationBuilder.RenameTable(
                name: "Pos_MethodOfPayments",
                newName: "Pos_MethodOfPayment");

            migrationBuilder.RenameTable(
                name: "Pos_CompanyInvoiceNumbers",
                newName: "CompanyInvoiceNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_MethodOfPayment",
                table: "Pos_MethodOfPayment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyInvoiceNumbers",
                table: "CompanyInvoiceNumbers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_OrderPayment_Pos_MethodOfPayment_MethodOfPaymentId",
                table: "Pos_OrderPayment",
                column: "MethodOfPaymentId",
                principalTable: "Pos_MethodOfPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
