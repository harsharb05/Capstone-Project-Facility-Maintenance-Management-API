using System;
using FacilityMaintenanceMngAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FacilityMaintenanceMngAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "10.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FacilityMaintenanceMngAPI.Models.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("FacilityMaintenanceMngAPI.Models.MaintenanceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("FacilityId")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("Status");

                    b.HasIndex("TechnicianId");

                    b.ToTable("MaintenanceRequests");
                });

            modelBuilder.Entity("FacilityMaintenanceMngAPI.Models.Technician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.Property<string>("Skill")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Technicians");
                });

            modelBuilder.Entity("FacilityMaintenanceMngAPI.Models.MaintenanceRequest", b =>
                {
                    b.HasOne("FacilityMaintenanceMngAPI.Models.Facility", "Facility")
                        .WithMany("MaintenanceRequests")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacilityMaintenanceMngAPI.Models.Technician", "Technician")
                        .WithMany("AssignedRequests")
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Facility");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("FacilityMaintenanceMngAPI.Models.Facility", b =>
                {
                    b.Navigation("MaintenanceRequests");
                });

            modelBuilder.Entity("FacilityMaintenanceMngAPI.Models.Technician", b =>
                {
                    b.Navigation("AssignedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
