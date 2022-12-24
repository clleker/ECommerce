using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.src.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class V8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSetting_Customers_CustomerId",
                table: "CustomerSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSetting",
                table: "CustomerSetting");

            migrationBuilder.RenameTable(
                name: "CustomerSetting",
                newName: "CustomerSettings");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSetting_CustomerId",
                table: "CustomerSettings",
                newName: "IX_CustomerSettings_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSettings",
                table: "CustomerSettings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSettings_Customers_CustomerId",
                table: "CustomerSettings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerSettings_Customers_CustomerId",
                table: "CustomerSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerSettings",
                table: "CustomerSettings");

            migrationBuilder.RenameTable(
                name: "CustomerSettings",
                newName: "CustomerSetting");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerSettings_CustomerId",
                table: "CustomerSetting",
                newName: "IX_CustomerSetting_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerSetting",
                table: "CustomerSetting",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerSetting_Customers_CustomerId",
                table: "CustomerSetting",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
