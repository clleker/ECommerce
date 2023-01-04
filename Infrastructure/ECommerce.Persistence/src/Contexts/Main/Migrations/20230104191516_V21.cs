using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.src.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class V21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCardPicture_Pictures_PictureId",
                table: "ProductCardPicture");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCardPicture_ProductCards_ProductCardId",
                table: "ProductCardPicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCardPicture",
                table: "ProductCardPicture");

            migrationBuilder.RenameTable(
                name: "ProductCardPicture",
                newName: "ProductCardPictures");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCardPicture_ProductCardId",
                table: "ProductCardPictures",
                newName: "IX_ProductCardPictures_ProductCardId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCardPicture_PictureId",
                table: "ProductCardPictures",
                newName: "IX_ProductCardPictures_PictureId");

            migrationBuilder.AlterColumn<int>(
                name: "FileType",
                table: "Pictures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCardPictures",
                table: "ProductCardPictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCardPictures_Pictures_PictureId",
                table: "ProductCardPictures",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCardPictures_ProductCards_ProductCardId",
                table: "ProductCardPictures",
                column: "ProductCardId",
                principalTable: "ProductCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCardPictures_Pictures_PictureId",
                table: "ProductCardPictures");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCardPictures_ProductCards_ProductCardId",
                table: "ProductCardPictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCardPictures",
                table: "ProductCardPictures");

            migrationBuilder.RenameTable(
                name: "ProductCardPictures",
                newName: "ProductCardPicture");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCardPictures_ProductCardId",
                table: "ProductCardPicture",
                newName: "IX_ProductCardPicture_ProductCardId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCardPictures_PictureId",
                table: "ProductCardPicture",
                newName: "IX_ProductCardPicture_PictureId");

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Pictures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCardPicture",
                table: "ProductCardPicture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCardPicture_Pictures_PictureId",
                table: "ProductCardPicture",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCardPicture_ProductCards_ProductCardId",
                table: "ProductCardPicture",
                column: "ProductCardId",
                principalTable: "ProductCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
