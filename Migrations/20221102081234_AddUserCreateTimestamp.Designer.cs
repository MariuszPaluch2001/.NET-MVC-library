﻿// <auto-generated />
using System;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagement.Migrations
{
    [DbContext(typeof(ManagerContext))]
    [Migration("20221102081234_AddUserCreateTimestamp")]
    partial class AddUserCreateTimestamp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int?>("User")
                        .HasColumnType("int");

                    b.Property<string>("author")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("bookAddTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("date")
                        .HasColumnType("int");

                    b.Property<DateTime?>("leased")
                        .HasColumnType("datetime2");

                    b.Property<string>("publisher")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("reserved")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("id");

                    b.HasIndex("User");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManagement.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<bool>("isSuperUser")
                        .HasColumnType("bit");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("userCreateTimestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.HasOne("LibraryManagement.Models.User", "user")
                        .WithMany("books")
                        .HasForeignKey("User");

                    b.Navigation("user");
                });

            modelBuilder.Entity("LibraryManagement.Models.User", b =>
                {
                    b.Navigation("books");
                });
#pragma warning restore 612, 618
        }
    }
}
