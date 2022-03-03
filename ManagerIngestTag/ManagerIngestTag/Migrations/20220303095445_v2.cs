using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PositionId",
                table: "IngestTags",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngestTags_PositionId",
                table: "IngestTags",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngestTags_Positions_PositionId",
                table: "IngestTags",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngestTags_Positions_PositionId",
                table: "IngestTags");

            migrationBuilder.DropIndex(
                name: "IX_IngestTags_PositionId",
                table: "IngestTags");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "IngestTags");
        }
    }
}
