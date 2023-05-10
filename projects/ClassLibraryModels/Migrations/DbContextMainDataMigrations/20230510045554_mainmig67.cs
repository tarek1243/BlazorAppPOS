using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig67 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_ProductId",
                table: "Pos_RelatedProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Pos_RelatedProducts",
                newName: "Related_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_RelatedProducts_ProductId",
                table: "Pos_RelatedProducts",
                newName: "IX_Pos_RelatedProducts_Related_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Parent_ProductId",
                table: "Pos_RelatedProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pos_RelatedProducts_Parent_ProductId",
                table: "Pos_RelatedProducts",
                column: "Parent_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_Parent_ProductId",
                table: "Pos_RelatedProducts",
                column: "Parent_ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_Related_ProductId",
                table: "Pos_RelatedProducts",
                column: "Related_ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_Parent_ProductId",
                table: "Pos_RelatedProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_Related_ProductId",
                table: "Pos_RelatedProducts");

            migrationBuilder.DropIndex(
                name: "IX_Pos_RelatedProducts_Parent_ProductId",
                table: "Pos_RelatedProducts");

            migrationBuilder.DropColumn(
                name: "Parent_ProductId",
                table: "Pos_RelatedProducts");

            migrationBuilder.RenameColumn(
                name: "Related_ProductId",
                table: "Pos_RelatedProducts",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_RelatedProducts_Related_ProductId",
                table: "Pos_RelatedProducts",
                newName: "IX_Pos_RelatedProducts_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_RelatedProducts_Pos_Products_ProductId",
                table: "Pos_RelatedProducts",
                column: "ProductId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
