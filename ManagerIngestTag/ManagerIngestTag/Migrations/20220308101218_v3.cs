using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketIngests_StatusIngests_StatusIngestId",
                table: "TicketIngests");

            migrationBuilder.DropIndex(
                name: "IX_TicketIngests_StatusIngestId",
                table: "TicketIngests");

            migrationBuilder.DropColumn(
                name: "StatusIngestId",
                table: "TicketIngests");

            migrationBuilder.AddColumn<string>(
                name: "StatusIngest",
                table: "TicketIngests",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusIngest",
                table: "TicketIngests");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusIngestId",
                table: "TicketIngests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketIngests_StatusIngestId",
                table: "TicketIngests",
                column: "StatusIngestId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketIngests_StatusIngests_StatusIngestId",
                table: "TicketIngests",
                column: "StatusIngestId",
                principalTable: "StatusIngests",
                principalColumn: "StatusIngestId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
