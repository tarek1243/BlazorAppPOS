using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig50 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Pos_Orders_OrderId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Pos_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem");

            migrationBuilder.RenameTable(
                name: "CartItem",
                newName: "Pos_CartItems");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "Pos_CartItems",
                newName: "IX_Pos_CartItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_OrderId",
                table: "Pos_CartItems",
                newName: "IX_Pos_CartItems_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_CartItems",
                table: "Pos_CartItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_CartItems_Pos_Orders_OrderId",
                table: "Pos_CartItems",
                column: "OrderId",
                principalTable: "Pos_Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_CartItems_Pos_Products_ProductId",
                table: "Pos_CartItems",
                column: "ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_CartItems_Pos_Orders_OrderId",
                table: "Pos_CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_CartItems_Pos_Products_ProductId",
                table: "Pos_CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_CartItems",
                table: "Pos_CartItems");

            migrationBuilder.RenameTable(
                name: "Pos_CartItems",
                newName: "CartItem");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_CartItems_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_CartItems_OrderId",
                table: "CartItem",
                newName: "IX_CartItem_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartItem",
                table: "CartItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Pos_Orders_OrderId",
                table: "CartItem",
                column: "OrderId",
                principalTable: "Pos_Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Pos_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
