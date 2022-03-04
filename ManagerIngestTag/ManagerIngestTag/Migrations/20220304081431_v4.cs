using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cardholderName",
                table: "IngestTags");

            migrationBuilder.AddColumn<Guid>(
                name: "cardholderId",
                table: "IngestTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_IngestTags_cardholderId",
                table: "IngestTags",
                column: "cardholderId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngestTags_Employees_cardholderId",
                table: "IngestTags",
                column: "cardholderId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngestTags_Employees_cardholderId",
                table: "IngestTags");

            migrationBuilder.DropIndex(
                name: "IX_IngestTags_cardholderId",
                table: "IngestTags");

            migrationBuilder.DropColumn(
                name: "cardholderId",
                table: "IngestTags");

            migrationBuilder.AddColumn<string>(
                name: "cardholderName",
                table: "IngestTags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
