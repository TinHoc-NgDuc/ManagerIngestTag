using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IngestTagId",
                table: "IngestDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngestDetails_IngestTagId",
                table: "IngestDetails",
                column: "IngestTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngestDetails_IngestTags_IngestTagId",
                table: "IngestDetails",
                column: "IngestTagId",
                principalTable: "IngestTags",
                principalColumn: "IngestTagId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngestDetails_IngestTags_IngestTagId",
                table: "IngestDetails");

            migrationBuilder.DropIndex(
                name: "IX_IngestDetails_IngestTagId",
                table: "IngestDetails");

            migrationBuilder.DropColumn(
                name: "IngestTagId",
                table: "IngestDetails");
        }
    }
}
