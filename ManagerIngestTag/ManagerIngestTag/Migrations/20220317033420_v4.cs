using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Roles_RoleId",
                table: "UserLogins");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "UserLogins",
                newName: "PositionId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_RoleId",
                table: "UserLogins",
                newName: "IX_UserLogins_PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Positions_PositionId",
                table: "UserLogins",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Positions_PositionId",
                table: "UserLogins");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "UserLogins",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_PositionId",
                table: "UserLogins",
                newName: "IX_UserLogins_RoleId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Roles_RoleId",
                table: "UserLogins",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
