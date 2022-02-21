using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerIngestTag.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IngestTags",
                columns: table => new
                {
                    IngestTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestTags", x => x.IngestTagId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionUnits",
                columns: table => new
                {
                    ProductionUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionUnits", x => x.ProductionUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    PropgramId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.PropgramId);
                });

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

            migrationBuilder.CreateTable(
                name: "StatusIngests",
                columns: table => new
                {
                    StatusIngestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusIngests", x => x.StatusIngestId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameramanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsReporting = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsCategory = table.Column<bool>(type: "bit", nullable: false),
                    IsOtherProgram = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "HistoryIngests",
                columns: table => new
                {
                    HistoryIngestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IngestTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryIngests", x => x.HistoryIngestId);
                    table.ForeignKey(
                        name: "FK_HistoryIngests_IngestTags_IngestTagId",
                        column: x => x.IngestTagId,
                        principalTable: "IngestTags",
                        principalColumn: "IngestTagId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_ProductionUnits_ProductionUnitId",
                        column: x => x.ProductionUnitId,
                        principalTable: "ProductionUnits",
                        principalColumn: "ProductionUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserLoginId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserLoginId);
                    table.ForeignKey(
                        name: "FK_UserLogins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketIngests",
                columns: table => new
                {
                    TicketIngestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CameramanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReporterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaveDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReporting = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsCategory = table.Column<bool>(type: "bit", nullable: false),
                    IsOtherProgram = table.Column<bool>(type: "bit", nullable: false),
                    StatusIngestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketIngests", x => x.TicketIngestId);
                    table.ForeignKey(
                        name: "FK_TicketIngests_StatusIngests_StatusIngestId",
                        column: x => x.StatusIngestId,
                        principalTable: "StatusIngests",
                        principalColumn: "StatusIngestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngestDetails",
                columns: table => new
                {
                    IngestDeltailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketIngestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IngestTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestDetails", x => x.IngestDeltailId);
                    table.ForeignKey(
                        name: "FK_IngestDetails_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngestDetails_IngestTags_IngestTagId",
                        column: x => x.IngestTagId,
                        principalTable: "IngestTags",
                        principalColumn: "IngestTagId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngestDetails_TicketIngests_TicketIngestId",
                        column: x => x.TicketIngestId,
                        principalTable: "TicketIngests",
                        principalColumn: "TicketIngestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProductionUnitId",
                table: "Employees",
                column: "ProductionUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryIngests_IngestTagId",
                table: "HistoryIngests",
                column: "IngestTagId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestDetails_CategoryId",
                table: "IngestDetails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestDetails_IngestTagId",
                table: "IngestDetails",
                column: "IngestTagId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestDetails_TicketIngestId",
                table: "IngestDetails",
                column: "TicketIngestId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIngests_StatusIngestId",
                table: "TicketIngests",
                column: "StatusIngestId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_RoleId",
                table: "UserLogins",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "HistoryIngests");

            migrationBuilder.DropTable(
                name: "IngestDetails");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ProductionUnits");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "IngestTags");

            migrationBuilder.DropTable(
                name: "TicketIngests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StatusIngests");
        }
    }
}
