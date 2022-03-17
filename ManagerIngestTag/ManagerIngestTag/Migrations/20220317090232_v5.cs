using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TicketIngestId",
                table: "HistoryIngests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryIngests_TicketIngestId",
                table: "HistoryIngests",
                column: "TicketIngestId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryIngests_TicketIngests_TicketIngestId",
                table: "HistoryIngests",
                column: "TicketIngestId",
                principalTable: "TicketIngests",
                principalColumn: "TicketIngestId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryIngests_TicketIngests_TicketIngestId",
                table: "HistoryIngests");

            migrationBuilder.DropIndex(
                name: "IX_HistoryIngests_TicketIngestId",
                table: "HistoryIngests");

            migrationBuilder.DropColumn(
                name: "TicketIngestId",
                table: "HistoryIngests");
        }
    }
}
