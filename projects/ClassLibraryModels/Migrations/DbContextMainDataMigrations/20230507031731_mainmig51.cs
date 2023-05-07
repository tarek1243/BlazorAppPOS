using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassLibraryModels.Migrations.DbContextMainDataMigrations
{
    /// <inheritdoc />
    public partial class mainmig51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_Pos_ProductTags_ProductTagsId",
                table: "ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProductTag_Pos_Products_ProductsId",
                table: "ProductProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProductTag",
                table: "ProductProductTag");

            migrationBuilder.RenameTable(
                name: "ProductProductTag",
                newName: "Pos_ProductProductTag");

            migrationBuilder.RenameIndex(
                name: "IX_ProductProductTag_ProductsId",
                table: "Pos_ProductProductTag",
                newName: "IX_Pos_ProductProductTag_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pos_ProductProductTag",
                table: "Pos_ProductProductTag",
                columns: new[] { "ProductTagsId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_ProductProductTag_Pos_ProductTags_ProductTagsId",
                table: "Pos_ProductProductTag",
                column: "ProductTagsId",
                principalTable: "Pos_ProductTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pos_ProductProductTag_Pos_Products_ProductsId",
                table: "Pos_ProductProductTag",
                column: "ProductsId",
                principalTable: "Pos_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pos_ProductProductTag_Pos_ProductTags_ProductTagsId",
                table: "Pos_ProductProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Pos_ProductProductTag_Pos_Products_ProductsId",
                table: "Pos_ProductProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pos_ProductProductTag",
                table: "Pos_ProductProductTag");

            migrationBuilder.RenameTable(
                name: "Pos_ProductProductTag",
                newName: "ProductProductTag");

            migrationBuilder.RenameIndex(
                name: "IX_Pos_ProductProductTag_ProductsId",
                table: "ProductProductTag",
                newName: "IX_ProductProductTag_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProductTag",
                table: "ProductProductTag",
                columns: new[] { "ProductTagsId", "ProductsId" });

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
    }
}
