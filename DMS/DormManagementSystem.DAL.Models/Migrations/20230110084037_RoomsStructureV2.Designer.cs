﻿// <auto-generated />
using System;
using DormManagementSystem.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DormManagementSystem.DAL.Models.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230110084037_RoomsStructureV2")]
    partial class RoomsStructureV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Floor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Level")
                        .IsUnique();

                    b.ToTable("Floors");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Malfunction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActualFixTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("ExpectedFixTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFixed")
                        .HasColumnType("bit");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("StudentId");

                    b.ToTable("Malfunctions");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FloorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoomNumber")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.HasIndex("FloorId");

                    b.HasIndex("RoomNumber")
                        .IsUnique()
                        .HasFilter("[RoomNumber] IS NOT NULL");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Shift", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("JMBG")
                        .IsUnique();

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("EmployeeShift", b =>
                {
                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShiftsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeesId", "ShiftsId");

                    b.HasIndex("ShiftsId");

                    b.ToTable("EmployeeShift");
                });

            modelBuilder.Entity("JanitorMalfunction", b =>
                {
                    b.Property<Guid>("JanitorsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MalfunctionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("JanitorsId", "MalfunctionsId");

                    b.HasIndex("MalfunctionsId");

                    b.ToTable("JanitorMalfunction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Employee", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.User");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Entertainment", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.Room");

                    b.ToTable("Entertainments");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Laundry", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.Room");

                    b.ToTable("Laundries");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Residency", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.Room");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.ToTable("Residencies");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Student", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.User");

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IndexNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("ResidencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ResidencyId");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Warden", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.User");

                    b.ToTable("Wardens", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Doorkeeper", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.Employee");

                    b.ToTable("Doorkeepers", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Janitor", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.Employee");

                    b.ToTable("Janitors", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Maid", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.Employee");

                    b.Property<Guid?>("FloorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("FloorId")
                        .IsUnique()
                        .HasFilter("[FloorId] IS NOT NULL");

                    b.ToTable("Maids", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Malfunction", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DormManagementSystem.DAL.Models.Models.Student", "Student")
                        .WithMany("Malfunctions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Room", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Floor", "Floor")
                        .WithMany("Rooms")
                        .HasForeignKey("FloorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.User", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Account", "Account")
                        .WithOne("User")
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("EmployeeShift", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DormManagementSystem.DAL.Models.Models.Shift", null)
                        .WithMany()
                        .HasForeignKey("ShiftsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JanitorMalfunction", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Janitor", null)
                        .WithMany()
                        .HasForeignKey("JanitorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DormManagementSystem.DAL.Models.Models.Malfunction", null)
                        .WithMany()
                        .HasForeignKey("MalfunctionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DormManagementSystem.DAL.Models.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Account", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Employee", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.User", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Entertainment", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Room", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Entertainment", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Laundry", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Room", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Laundry", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Residency", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Room", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Residency", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Student", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.User", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Student", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("DormManagementSystem.DAL.Models.Models.Residency", "Residency")
                        .WithMany("Students")
                        .HasForeignKey("ResidencyId");

                    b.Navigation("Residency");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Warden", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.User", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Warden", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Doorkeeper", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Doorkeeper", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Janitor", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Janitor", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Maid", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Floor", "Floor")
                        .WithOne("Maid")
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Maid", "FloorId");

                    b.HasOne("DormManagementSystem.DAL.Models.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Maid", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Floor");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Account", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Floor", b =>
                {
                    b.Navigation("Maid");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Residency", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Student", b =>
                {
                    b.Navigation("Malfunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
