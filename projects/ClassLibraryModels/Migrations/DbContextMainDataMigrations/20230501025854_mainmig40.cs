using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Orders_OrderId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Companies_CompanyId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shifts_shift_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_ProductTags_ProductTagsId",
                table: "ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_Products_ProductsId",
                table: "ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "Pos_Shifts");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "Pos_ProductTags");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Pos_Products");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Pos_Orders");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Pos_Customers");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Pos_Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "Pos_Products",
                newName: "IX_Pos_Products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_shift_Id",
                table: "Pos_Orders",
                newName: "IX_Pos_Orders_shift_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerId",
                table: "Pos_Orders",
                newName: "IX_Pos_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CompanyId",
                table: "Pos_Orders",
                newName: "IX_Pos_Orders_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_Shifts",
                table: "Pos_Shifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_ProductTags",
                table: "Pos_ProductTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_Products",
                table: "Pos_Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_Orders",
                table: "Pos_Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_Customers",
                table: "Pos_Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_Companies",
                table: "Pos_Companies",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Orders_Pos_Companies_CompanyId",
                table: "Pos_Orders",
                column: "CompanyId",
                principalTable: "Pos_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Orders_Pos_Customers_CustomerId",
                table: "Pos_Orders",
                column: "CustomerId",
                principalTable: "Pos_Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Orders_Pos_Shifts_shift_Id",
                table: "Pos_Orders",
                column: "shift_Id",
                principalTable: "Pos_Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_Products_Pos_Companies_CompanyId",
                table: "Pos_Products",
                column: "CompanyId",
                principalTable: "Pos_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductTag_Pos_ProductTags_ProductTagsId",
                table: "ProductProductTag",
                column: "ProductTagsId",
                principalTable: "Pos_ProductTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductTag_Pos_Products_ProductsId",
                table: "ProductProductTag",
                column: "ProductsId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Pos_Orders_OrderId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Pos_Products_ProductId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Orders_Pos_Companies_CompanyId",
                table: "Pos_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Orders_Pos_Customers_CustomerId",
                table: "Pos_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Orders_Pos_Shifts_shift_Id",
                table: "Pos_Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_Products_Pos_Companies_CompanyId",
                table: "Pos_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_Pos_ProductTags_ProductTagsId",
                table: "ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_Pos_Products_ProductsId",
                table: "ProductProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_Shifts",
                table: "Pos_Shifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_ProductTags",
                table: "Pos_ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_Products",
                table: "Pos_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_Orders",
                table: "Pos_Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_Customers",
                table: "Pos_Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_Companies",
                table: "Pos_Companies");

            migrationBuilder.RenameTable(
                name: "Pos_Shifts",
                newName: "Shifts");

            migrationBuilder.RenameTable(
                name: "Pos_ProductTags",
                newName: "ProductTags");

            migrationBuilder.RenameTable(
                name: "Pos_Products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Pos_Orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Pos_Customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Pos_Companies",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_Products_CompanyId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_Orders_shift_Id",
                table: "Orders",
                newName: "IX_Orders_shift_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_Orders_CustomerId",
                table: "Orders",
                newName: "IX_Orders_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_Orders_CompanyId",
                table: "Orders",
                newName: "IX_Orders_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Orders_OrderId",
                table: "CartItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Products_ProductId",
                table: "CartItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Companies_CompanyId",
                table: "Orders",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shifts_shift_Id",
                table: "Orders",
                column: "shift_Id",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductTag_ProductTags_ProductTagsId",
                table: "ProductProductTag",
                column: "ProductTagsId",
                principalTable: "ProductTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProductTag_Products_ProductsId",
                table: "ProductProductTag",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
