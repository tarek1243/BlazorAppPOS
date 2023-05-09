using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig65 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedProduct_Pos_Products_ProductId",
                table: "RelatedProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RelatedProduct",
                table: "RelatedProduct");

            migrationBuilder.RenameTable(
                name: "RelatedProduct",
                newName: "Pos_RelatedProducts");

            migrationBuilder.RenameIndex(
                name: "IX_RelatedProduct_ProductId",
                table: "Pos_RelatedProducts",
                newName: "IX_Pos_RelatedProducts_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_RelatedProducts",
                table: "Pos_RelatedProducts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_ProductId",
                table: "Pos_RelatedProducts",
                column: "ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_ProductId",
                table: "Pos_RelatedProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_RelatedProducts",
                table: "Pos_RelatedProducts");

            migrationBuilder.RenameTable(
                name: "Pos_RelatedProducts",
                newName: "RelatedProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_RelatedProducts_ProductId",
                table: "RelatedProduct",
                newName: "IX_RelatedProduct_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RelatedProduct",
                table: "RelatedProduct",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedProduct_Pos_Products_ProductId",
                table: "RelatedProduct",
                column: "ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
