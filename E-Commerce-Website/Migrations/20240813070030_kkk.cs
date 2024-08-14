using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce_Website.Migrations
{
    /// <inheritdoc />
    public partial class kkk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_products_cat_id",
                table: "tbl_products",
                column: "cat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_products_tbl_categories_cat_id",
                table: "tbl_products",
                column: "cat_id",
                principalTable: "tbl_categories",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_products_tbl_categories_cat_id",
                table: "tbl_products");

            migrationBuilder.DropIndex(
                name: "IX_tbl_products_cat_id",
                table: "tbl_products");
        }
    }
}
