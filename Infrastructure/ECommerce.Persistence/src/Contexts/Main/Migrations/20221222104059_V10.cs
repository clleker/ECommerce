using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.src.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class V10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmEmail",
                table: "CustomerSettings");

            migrationBuilder.DropColumn(
                name: "IsConfirmPhone",
                table: "CustomerSettings");

            migrationBuilder.DropColumn(
                name: "LastLoginDateUtc",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmEmail",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmPhone",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterEmailConfirmDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConfirmEmail",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "IsConfirmPhone",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegisterEmailConfirmDate",
                table: "Customers");

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmEmail",
                table: "CustomerSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmPhone",
                table: "CustomerSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDateUtc",
                table: "Customers",
                type: "datetime2",
                nullable: true);
        }
    }
}
