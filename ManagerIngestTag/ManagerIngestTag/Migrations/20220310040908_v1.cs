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
                name: "ProgramShows",
                columns: table => new
                {
                    PropgramShowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramShows", x => x.PropgramShowId);
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
                    StatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusIngests", x => x.StatusIngestId);
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
                    StatusIngest = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketIngests", x => x.TicketIngestId);
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
                name: "IngestDetails",
                columns: table => new
                {
                    IngestDeltailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketIngestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeeSend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeReceive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateSend = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestDetails", x => x.IngestDeltailId);
                    table.ForeignKey(
                        name: "FK_IngestDetails_TicketIngests_TicketIngestId",
                        column: x => x.TicketIngestId,
                        principalTable: "TicketIngests",
                        principalColumn: "TicketIngestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngestTags",
                columns: table => new
                {
                    IngestTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngestCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    cardholderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestTags", x => x.IngestTagId);
                    table.ForeignKey(
                        name: "FK_IngestTags_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngestTags_Employees_cardholderId",
                        column: x => x.cardholderId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_IngestDetails_TicketIngestId",
                table: "IngestDetails",
                column: "TicketIngestId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestTags_cardholderId",
                table: "IngestTags",
                column: "cardholderId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestTags_CategoryId",
                table: "IngestTags",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_RoleId",
                table: "UserLogins",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryIngests");

            migrationBuilder.DropTable(
                name: "IngestDetails");

            migrationBuilder.DropTable(
                name: "ProgramShows");

            migrationBuilder.DropTable(
                name: "StatusIngests");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "IngestTags");

            migrationBuilder.DropTable(
                name: "TicketIngests");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ProductionUnits");
        }
    }
}
