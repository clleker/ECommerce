using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.src.Contexts.Main.Migrations
{
    /// <inheritdoc />
    public partial class V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthGroupRole_AuthGroup_AuthGroupId",
                table: "AuthGroupRole");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthGroupRole_Roles_RoleId",
                table: "AuthGroupRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthGroup_AuthGroup_AuthGroupId",
                table: "UserAuthGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthGroup_Users_UserId",
                table: "UserAuthGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthGroup",
                table: "UserAuthGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthGroupRole",
                table: "AuthGroupRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthGroup",
                table: "AuthGroup");

            migrationBuilder.RenameTable(
                name: "UserAuthGroup",
                newName: "UserAuthGroups");

            migrationBuilder.RenameTable(
                name: "AuthGroupRole",
                newName: "AuthGroupRoles");

            migrationBuilder.RenameTable(
                name: "AuthGroup",
                newName: "AuthGroups");

            migrationBuilder.RenameIndex(
                name: "IX_UserAuthGroup_UserId",
                table: "UserAuthGroups",
                newName: "IX_UserAuthGroups_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAuthGroup_AuthGroupId",
                table: "UserAuthGroups",
                newName: "IX_UserAuthGroups_AuthGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthGroupRole_RoleId",
                table: "AuthGroupRoles",
                newName: "IX_AuthGroupRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthGroupRole_AuthGroupId",
                table: "AuthGroupRoles",
                newName: "IX_AuthGroupRoles_AuthGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthGroups",
                table: "UserAuthGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthGroupRoles",
                table: "AuthGroupRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthGroups",
                table: "AuthGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthGroupRoles_AuthGroups_AuthGroupId",
                table: "AuthGroupRoles",
                column: "AuthGroupId",
                principalTable: "AuthGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthGroupRoles_Roles_RoleId",
                table: "AuthGroupRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthGroups_AuthGroups_AuthGroupId",
                table: "UserAuthGroups",
                column: "AuthGroupId",
                principalTable: "AuthGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthGroups_Users_UserId",
                table: "UserAuthGroups",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthGroupRoles_AuthGroups_AuthGroupId",
                table: "AuthGroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthGroupRoles_Roles_RoleId",
                table: "AuthGroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthGroups_AuthGroups_AuthGroupId",
                table: "UserAuthGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAuthGroups_Users_UserId",
                table: "UserAuthGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAuthGroups",
                table: "UserAuthGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthGroups",
                table: "AuthGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthGroupRoles",
                table: "AuthGroupRoles");

            migrationBuilder.RenameTable(
                name: "UserAuthGroups",
                newName: "UserAuthGroup");

            migrationBuilder.RenameTable(
                name: "AuthGroups",
                newName: "AuthGroup");

            migrationBuilder.RenameTable(
                name: "AuthGroupRoles",
                newName: "AuthGroupRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserAuthGroups_UserId",
                table: "UserAuthGroup",
                newName: "IX_UserAuthGroup_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAuthGroups_AuthGroupId",
                table: "UserAuthGroup",
                newName: "IX_UserAuthGroup_AuthGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthGroupRoles_RoleId",
                table: "AuthGroupRole",
                newName: "IX_AuthGroupRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AuthGroupRoles_AuthGroupId",
                table: "AuthGroupRole",
                newName: "IX_AuthGroupRole_AuthGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAuthGroup",
                table: "UserAuthGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthGroup",
                table: "AuthGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthGroupRole",
                table: "AuthGroupRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthGroupRole_AuthGroup_AuthGroupId",
                table: "AuthGroupRole",
                column: "AuthGroupId",
                principalTable: "AuthGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthGroupRole_Roles_RoleId",
                table: "AuthGroupRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthGroup_AuthGroup_AuthGroupId",
                table: "UserAuthGroup",
                column: "AuthGroupId",
                principalTable: "AuthGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuthGroup_Users_UserId",
                table: "UserAuthGroup",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
