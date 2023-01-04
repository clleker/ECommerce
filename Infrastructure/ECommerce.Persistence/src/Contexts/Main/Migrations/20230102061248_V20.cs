using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.src.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class V20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ProductCardAttributes");

            migrationBuilder.AddColumn<int>(
                name: "ParentProductCardAttributeId",
                table: "ProductCardAttributes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCardAttributes_ParentProductCardAttributeId",
                table: "ProductCardAttributes",
                column: "ParentProductCardAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCardAttributes_ProductCardAttributes_ParentProductCardAttributeId",
                table: "ProductCardAttributes",
                column: "ParentProductCardAttributeId",
                principalTable: "ProductCardAttributes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCardAttributes_ProductCardAttributes_ParentProductCardAttributeId",
                table: "ProductCardAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductCardAttributes_ParentProductCardAttributeId",
                table: "ProductCardAttributes");

            migrationBuilder.DropColumn(
                name: "ParentProductCardAttributeId",
                table: "ProductCardAttributes");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ProductCardAttributes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
