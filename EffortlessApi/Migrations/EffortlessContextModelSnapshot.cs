﻿// <auto-generated />
using System;
using EffortlessApi.Models;
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

            modelBuilder.Entity("EffortlessApi.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EffortlessApi.Models.Hour", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CompanyId");

                    b.Property<long?>("OwnerId");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Stop");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("EffortlessApi.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EffortlessApi.Models.Hour", b =>
                {
                    b.HasOne("EffortlessApi.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("EffortlessApi.Models.User", "Owner")
                        .WithMany("Hours")
                        .HasForeignKey("OwnerId");
                });
#pragma warning restore 612, 618
        }
    }
}
