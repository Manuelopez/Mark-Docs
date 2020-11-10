﻿// <auto-generated />
using System;
using LeagueServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LeagueServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201104231148_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("LeagueServer.Data.Build", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Items")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Owner")
                        .HasColumnType("integer");

                    b.Property<string>("Runes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Builds");
                });

            modelBuilder.Entity("LeagueServer.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("BuildId")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("Owner")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BuildId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("LeagueServer.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Bio")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LeagueServer.Data.Build", b =>
                {
                    b.HasOne("LeagueServer.Data.Customer", null)
                        .WithMany("Builds")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("LeagueServer.Data.Comment", b =>
                {
                    b.HasOne("LeagueServer.Data.Build", null)
                        .WithMany("Comments")
                        .HasForeignKey("BuildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeagueServer.Data.Customer", null)
                        .WithMany("Comments")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("LeagueServer.Data.Build", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("LeagueServer.Data.Customer", b =>
                {
                    b.Navigation("Builds");

                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}