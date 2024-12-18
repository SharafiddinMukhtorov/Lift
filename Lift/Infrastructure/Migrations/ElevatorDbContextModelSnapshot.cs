﻿// <auto-generated />
using System;
using Lift.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Lift.Infrastructure.Migrations
{
    [DbContext(typeof(ElevatorDbContext))]
    partial class ElevatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActualLab.Fusion.Authentication.Services.DbSessionInfo<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("AuthenticatedIdentity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSignOutForced")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastSeenAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OptionsJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt", "IsSignOutForced");

                    b.HasIndex("IPAddress", "IsSignOutForced");

                    b.HasIndex("LastSeenAt", "IsSignOutForced");

                    b.HasIndex("UserId", "IsSignOutForced");

                    b.ToTable("_Sessions");
                });

            modelBuilder.Entity("ActualLab.Fusion.Authentication.Services.DbUser<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClaimsJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActualLab.Fusion.Authentication.Services.DbUserIdentity<string>", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("DbUserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("UserId");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DbUserId");

                    b.HasIndex("Id");

                    b.ToTable("UserIdentities");
                });

            modelBuilder.Entity("ActualLab.Fusion.EntityFramework.Operations.DbEvent", b =>
                {
                    b.Property<string>("Uuid")
                        .HasColumnType("text");

                    b.Property<DateTime>("DelayUntil")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LoggedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<string>("ValueJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("bigint");

                    b.HasKey("Uuid");

                    b.HasIndex("DelayUntil");

                    b.HasIndex("State", "DelayUntil");

                    b.ToTable("_Events");
                });

            modelBuilder.Entity("ActualLab.Fusion.EntityFramework.Operations.DbOperation", b =>
                {
                    b.Property<long>("Index")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Index"));

                    b.Property<string>("CommandJson")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HostId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ItemsJson")
                        .HasColumnType("text");

                    b.Property<DateTime>("LoggedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NestedOperations")
                        .HasColumnType("text");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Index");

                    b.HasIndex("LoggedAt");

                    b.HasIndex("Uuid")
                        .IsUnique();

                    b.ToTable("_Operations");
                });

            modelBuilder.Entity("Lift.Models.ElevatorRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RequestTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RequestedFloor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ElevatorRequests");
                });

            modelBuilder.Entity("Lift.Models.ElevatorState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentFloor")
                        .HasColumnType("integer");

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBusy")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("ElevatorStates");
                });

            modelBuilder.Entity("ActualLab.Fusion.Authentication.Services.DbUserIdentity<string>", b =>
                {
                    b.HasOne("ActualLab.Fusion.Authentication.Services.DbUser<string>", null)
                        .WithMany("Identities")
                        .HasForeignKey("DbUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ActualLab.Fusion.Authentication.Services.DbUser<string>", b =>
                {
                    b.Navigation("Identities");
                });
#pragma warning restore 612, 618
        }
    }
}
