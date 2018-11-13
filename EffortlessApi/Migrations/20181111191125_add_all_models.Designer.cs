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
    [Migration("20181111191125_add_all_models")]
    partial class add_all_models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EffortlessApi.Models.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Country")
                        .IsRequired();

                    b.Property<string>("Floor");

                    b.Property<int>("No");

                    b.Property<string>("Road")
                        .IsRequired();

                    b.Property<string>("Side");

                    b.Property<int>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EffortlessApi.Models.Appointment", b =>
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

            modelBuilder.Entity("EffortlessApi.Models.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("EffortlessApi.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EffortlessApi.Models.Privilege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("Privileges");
                });

            modelBuilder.Entity("EffortlessApi.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("EffortlessApi.Models.RolePrivilege", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("PrivilegeId");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RolePrivileges");
                });

            modelBuilder.Entity("EffortlessApi.Models.TemporaryWorkPeriod", b =>
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

            modelBuilder.Entity("EffortlessApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EffortlessApi.Models.UserJobActive", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("JobId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UsersJobActive");
                });

            modelBuilder.Entity("EffortlessApi.Models.UserJobInactive", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("JobId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UsersJobInactive");
                });

            modelBuilder.Entity("EffortlessApi.Models.UserTemporaryWorkPeriod", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("TemporaryWorkPeriodId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserTemoraryWorkPeriods");
                });

            modelBuilder.Entity("EffortlessApi.Models.WorkingHours", b =>
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
#pragma warning restore 612, 618
        }
    }
}