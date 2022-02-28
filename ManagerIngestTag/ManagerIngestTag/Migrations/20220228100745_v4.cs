using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngestTags_Employees_Employee",
                table: "IngestTags");

            migrationBuilder.DropIndex(
                name: "IX_IngestTags_Employee",
                table: "IngestTags");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "IngestTags");

            migrationBuilder.AddColumn<Guid>(
                name: "cardholderCode",
                table: "IngestTags",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_IngestTags_cardholderCode",
                table: "IngestTags",
                column: "cardholderCode");

            migrationBuilder.AddForeignKey(
                name: "FK_IngestTags_Employees_cardholderCode",
                table: "IngestTags",
                column: "cardholderCode",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngestTags_Employees_cardholderCode",
                table: "IngestTags");

            migrationBuilder.DropIndex(
                name: "IX_IngestTags_cardholderCode",
                table: "IngestTags");

            migrationBuilder.DropColumn(
                name: "cardholderCode",
                table: "IngestTags");

            migrationBuilder.AddColumn<Guid>(
                name: "Employee",
                table: "IngestTags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngestTags_Employee",
                table: "IngestTags",
                column: "Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_IngestTags_Employees_Employee",
                table: "IngestTags",
                column: "Employee",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
