// <auto-generated />
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
    [Migration("20221102110552_ChangeBookIdFieldName")]
    partial class ChangeBookIdFieldName
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
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<int?>("Owner")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("BookAddTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Leased")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Reserved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("BookId");

                    b.HasIndex("Owner");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryManagement.Models.Owner", b =>
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
                    b.HasOne("LibraryManagement.Models.Owner", "Owner")
                        .WithMany("books")
                        .HasForeignKey("Owner");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("LibraryManagement.Models.Owner", b =>
                {
                    b.Navigation("books");
                });
#pragma warning restore 612, 618
        }
    }
}
