﻿// <auto-generated />
using System;
using EffortlessApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EffortlessApi.Migrations
{
    [DbContext(typeof(EffortlessContext))]
    [Migration("20181117191526_RefactorRoadToStreet")]
    partial class RefactorRoadToStreet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EffortlessApi.Core.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Floor");

                    b.Property<int>("No");

                    b.Property<string>("Side");

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Break");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Stop");

                    b.Property<long>("TemporaryWorkPeriodId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Privilege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Privileges");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.RolePrivilege", b =>
                {
                    b.Property<long>("RoleId");

                    b.Property<long>("PrivilegeId");

                    b.HasKey("RoleId", "PrivilegeId");

                    b.HasIndex("PrivilegeId");

                    b.ToTable("RolePrivileges");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.TemporaryWorkPeriod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("BreakIsPaid");

                    b.Property<long>("JobId");

                    b.Property<float>("Salary");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Stop");

                    b.Property<float>("UnitPrice");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("TemporaryWorkPeriods");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.UserJobActive", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("JobId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UsersJobActive");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.UserJobInactive", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("JobId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UsersJobInactive");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.UserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.UserTemporaryWorkPeriod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("TemporaryWorkPeriodId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserTemporaryWorkPeriods");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.WorkingHours", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AppointmentId");

                    b.Property<int>("Break");

                    b.Property<bool>("IsApproved");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Stop");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.RolePrivilege", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.Privilege", "Privilege")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("PrivilegeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.Role", "Role")
                        .WithMany("RolePrivileges")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.UserRole", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
