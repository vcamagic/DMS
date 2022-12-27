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
    [Migration("20221227084803_UpdatedMalfunction")]
    partial class UpdatedMalfunction
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

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Claim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Claims");
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

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Malfunction");
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

                    b.ToTable("Users");
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

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Employee", b =>
                {
                    b.HasBaseType("DormManagementSystem.DAL.Models.Models.User");

                    b.ToTable("Employees", (string)null);
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

                    b.ToTable("Maids", (string)null);
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Claim", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Account", "Account")
                        .WithMany("Claims")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Malfunction", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Student", "Student")
                        .WithMany("Malfunctions")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
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

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Employee", b =>
                {
                    b.HasOne("DormManagementSystem.DAL.Models.Models.User", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Employee", "Id")
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
                    b.HasOne("DormManagementSystem.DAL.Models.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("DormManagementSystem.DAL.Models.Models.Maid", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Account", b =>
                {
                    b.Navigation("Claims");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DormManagementSystem.DAL.Models.Models.Student", b =>
                {
                    b.Navigation("Malfunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
