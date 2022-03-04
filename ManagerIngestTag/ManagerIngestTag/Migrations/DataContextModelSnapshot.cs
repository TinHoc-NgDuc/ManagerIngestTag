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

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.CategoryModel", b =>
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

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("IngestTagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameAction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeAction")
                        .HasColumnType("datetime2");

                    b.HasKey("HistoryIngestId");

                    b.HasIndex("IngestTagId");

                    b.ToTable("HistoryIngests");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestDetail", b =>
                {
                    b.Property<Guid>("IngestDeltailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IngestTagId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TicketIngestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngestDeltailId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("IngestTagId");

                    b.HasIndex("TicketIngestId");

                    b.ToTable("IngestDetails");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestTag", b =>
                {
                    b.Property<Guid>("IngestTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IngestCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid>("cardholderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IngestTagId");

                    b.HasIndex("PositionId");

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

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.StatusIngest", b =>
                {
                    b.Property<Guid>("StatusIngestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
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

                    b.Property<Guid?>("StatusIngestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TopicName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TicketIngestId");

                    b.HasIndex("StatusIngestId");

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

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserLoginId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserLogins");
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
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.IngestTag", "IngestTag")
                        .WithMany()
                        .HasForeignKey("IngestTagId");

                    b.Navigation("IngestTag");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestDetail", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.IngestTag", "IngestTag")
                        .WithMany()
                        .HasForeignKey("IngestTagId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.TicketIngest", "TicketIngest")
                        .WithMany()
                        .HasForeignKey("TicketIngestId");

                    b.Navigation("Category");

                    b.Navigation("IngestTag");

                    b.Navigation("TicketIngest");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.IngestTag", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("cardholderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.TicketIngest", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.StatusIngest", "StatusIngest")
                        .WithMany()
                        .HasForeignKey("StatusIngestId");

                    b.Navigation("StatusIngest");
                });

            modelBuilder.Entity("ManagerIngest.Infrastructure.Datatable.UserLogin", b =>
                {
                    b.HasOne("ManagerIngest.Infrastructure.Datatable.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
