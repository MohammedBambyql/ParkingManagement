﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingManagement.Data;

#nullable disable

namespace ParkingManagement.Migrations
{
    [DbContext(typeof(ParkingContext))]
    [Migration("20241026172925_Add_Models_with_EF_core")]
    partial class Add_Models_with_EF_core
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ParkingManagement.Models.ParkingSpot", b =>
                {
                    b.Property<int>("SpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpotId"));

                    b.Property<bool>("IsOccupied")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SpotId");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("ParkingManagement.Models.ParkingTicket", b =>
                {
                    b.Property<int>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketId"));

                    b.Property<DateTime>("EntryTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("TicketId");

                    b.HasIndex("ParkingSpotId")
                        .IsUnique();

                    b.HasIndex("VehicleId")
                        .IsUnique();

                    b.ToTable("ParkingTickets");
                });

            modelBuilder.Entity("ParkingManagement.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("ParkingTicketId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PaymentId");

                    b.HasIndex("ParkingTicketId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("LicensePlateNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OwnerInfo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("ParkingManagement.Models.ParkingTicket", b =>
                {
                    b.HasOne("ParkingManagement.Models.ParkingSpot", "ParkingSpot")
                        .WithOne("ParkingTicket")
                        .HasForeignKey("ParkingManagement.Models.ParkingTicket", "ParkingSpotId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithOne("ParkingTicket")
                        .HasForeignKey("ParkingManagement.Models.ParkingTicket", "VehicleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ParkingSpot");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("ParkingManagement.Models.Payment", b =>
                {
                    b.HasOne("ParkingManagement.Models.ParkingTicket", "ParkingTicket")
                        .WithOne("Payment")
                        .HasForeignKey("ParkingManagement.Models.Payment", "ParkingTicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingTicket");
                });

            modelBuilder.Entity("ParkingManagement.Models.ParkingSpot", b =>
                {
                    b.Navigation("ParkingTicket")
                        .IsRequired();
                });

            modelBuilder.Entity("ParkingManagement.Models.ParkingTicket", b =>
                {
                    b.Navigation("Payment")
                        .IsRequired();
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Navigation("ParkingTicket")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
