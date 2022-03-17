﻿// <auto-generated />
using System;
using ManagerIngest.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagerIngestTag.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductionUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PositionId");

                    b.HasIndex("ProductionUnitId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.HistoryIngest", b =>
                {
                    b.Property<Guid>("HistoryIngestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IngestDetailIngestDeltailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Performer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TicketIngestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TimeAction")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HistoryIngestId");

                    b.HasIndex("IngestDetailIngestDeltailId");

                    b.HasIndex("TicketIngestId");

                    b.ToTable("HistoryIngests");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestDetail", b =>
                {
                    b.Property<Guid>("IngestDeltailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DateReturn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DateSend")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IngestTagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RecipientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TakerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TakerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TicketIngestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngestDeltailId");

                    b.HasIndex("IngestTagId");

                    b.HasIndex("TicketIngestId");

                    b.ToTable("IngestDetails");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestTag", b =>
                {
                    b.Property<Guid>("IngestTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IngestCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("cardholderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngestTagId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("cardholderId");

                    b.ToTable("IngestTags");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.Position", b =>
                {
                    b.Property<Guid>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.ProductionUnit", b =>
                {
                    b.Property<Guid>("ProductionUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductionUnitId");

                    b.ToTable("ProductionUnits");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.ProgramShow", b =>
                {
                    b.Property<Guid>("PropgramShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PropgramShowId");

                    b.ToTable("ProgramShows");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.StatusIngest", b =>
                {
                    b.Property<Guid>("StatusIngestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusIngestId");

                    b.ToTable("StatusIngests");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.TicketIngest", b =>
                {
                    b.Property<Guid>("TicketIngestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CameramanName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCategory")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOtherProgram")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReporting")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReporterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaveDocument")
                        .HasColumnType("datetime2");

                    b.Property<string>("StatusIngest")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketIngestId");

                    b.ToTable("TicketIngests");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.Topic", b =>
                {
                    b.Property<Guid>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CameramanName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCategory")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOtherProgram")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReporting")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReporterName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.UserLogin", b =>
                {
                    b.Property<Guid>("UserLoginId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserLoginId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("ManagerIngestTag.Infrastructure.Datatable.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.Employee", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.ProductionUnit", "ProductionUnit")
                        .WithMany()
                        .HasForeignKey("ProductionUnitId");

                    b.Navigation("Position");

                    b.Navigation("ProductionUnit");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.HistoryIngest", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.IngestDetail", "IngestDetail")
                        .WithMany()
                        .HasForeignKey("IngestDetailIngestDeltailId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.TicketIngest", "TicketIngest")
                        .WithMany()
                        .HasForeignKey("TicketIngestId");

                    b.Navigation("IngestDetail");

                    b.Navigation("TicketIngest");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestDetail", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.IngestTag", "IngestTag")
                        .WithMany()
                        .HasForeignKey("IngestTagId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.TicketIngest", "ticketIngest")
                        .WithMany()
                        .HasForeignKey("TicketIngestId");

                    b.Navigation("IngestTag");

                    b.Navigation("ticketIngest");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestTag", b =>
                {
                    b.HasOne("ManagerIngestTag.Infrastructure.Datatable.Category", "category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("cardholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.UserLogin", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Position", "position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.Navigation("Employee");

                    b.Navigation("position");
                });
#pragma warning restore 612, 618
        }
    }
}
