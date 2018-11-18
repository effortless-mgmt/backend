﻿// <auto-generated />
using System;
using EffortlessApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EffortlessApi.Migrations
{
    [DbContext(typeof(EffortlessContext))]
    partial class EffortlessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("State");

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

                    b.Property<bool>("ApprovedByOwner");

                    b.Property<DateTime>("ApprovedByOwnerDate");

                    b.Property<long>("ApprovedByUserId");

                    b.Property<DateTime>("ApprovedDate");

                    b.Property<long>("Break");

                    b.Property<long>("CreatedByUserId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("Earnings");

                    b.Property<long>("OwnerId");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Stop");

                    b.Property<long>("TemporaryWorkPeriodId");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedByUserId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TemporaryWorkPeriodId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("ParentCompanyId");

                    b.Property<int>("Pno");

                    b.Property<int>("Vat");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ParentCompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AddressId");

                    b.Property<long>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");
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

                    b.Property<long?>("TemporaryWorkPeriodId");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TemporaryWorkPeriodId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
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
                    b.Property<long>("UserId");

                    b.Property<long>("TemporaryWorkPeriodId");

                    b.Property<long?>("TemporaryWorkPeriodId1");

                    b.HasKey("UserId", "TemporaryWorkPeriodId");

                    b.HasIndex("TemporaryWorkPeriodId");

                    b.HasIndex("TemporaryWorkPeriodId1");

                    b.ToTable("UserTemporaryWorkPeriods");
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Appointment", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.User", "ApprovedBy")
                        .WithMany()
                        .HasForeignKey("ApprovedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.TemporaryWorkPeriod", "TemporaryWorkPeriod")
                        .WithMany()
                        .HasForeignKey("TemporaryWorkPeriodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Company", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.Company", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentCompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EffortlessApi.Core.Models.Department", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("EffortlessApi.Core.Models.User", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.TemporaryWorkPeriod")
                        .WithMany("AssignedUsers")
                        .HasForeignKey("TemporaryWorkPeriodId");
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

            modelBuilder.Entity("EffortlessApi.Core.Models.UserTemporaryWorkPeriod", b =>
                {
                    b.HasOne("EffortlessApi.Core.Models.TemporaryWorkPeriod", "TemporaryWorkPeriod")
                        .WithMany()
                        .HasForeignKey("TemporaryWorkPeriodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EffortlessApi.Core.Models.TemporaryWorkPeriod")
                        .WithMany("UserTemporaryWorkPeriods")
                        .HasForeignKey("TemporaryWorkPeriodId1")
                        .HasConstraintName("FK_UserTemporaryWorkPeriods_TemporaryWorkPeriods_TemporaryWor~1");

                    b.HasOne("EffortlessApi.Core.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
