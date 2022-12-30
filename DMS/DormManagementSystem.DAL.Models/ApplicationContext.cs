
using System.Diagnostics.CodeAnalysis;
using DormManagementSystem.DAL.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.DAL.Models;

public class ApplicationContext : IdentityDbContext<Account, Role, Guid>
{
    public ApplicationContext([NotNullAttribute] DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Account>()
        .HasOne(x => x.User)
        .WithOne(x => x.Account)
        .HasForeignKey<User>(x => x.AccountId);

        modelBuilder
        .Entity<User>()
        .Property(x => x.DateOfBirth)
        .HasColumnType("date");

        modelBuilder
        .Entity<User>()
        .HasIndex(x => x.JMBG)
        .IsUnique();

        modelBuilder
        .Entity<Warden>()
        .ToTable("Wardens");

        modelBuilder
        .Entity<Student>()
        .ToTable("Students")
        .HasMany(x => x.Malfunctions)
        .WithOne(x => x.Student);

        modelBuilder
        .Entity<Employee>()
        .ToTable("Employees");

        modelBuilder
        .Entity<Janitor>()
        .ToTable("Janitors");

        modelBuilder
        .Entity<Maid>()
        .ToTable("Maids");

        modelBuilder
        .Entity<Doorkeeper>()
        .ToTable("Doorkeepers");

        modelBuilder
        .Entity<Employee>()
        .HasMany(x => x.Shifts)
        .WithMany(x => x.Employees);

        modelBuilder
        .Entity<Janitor>()
        .HasMany(x => x.Malfunctions)
        .WithMany(x => x.Janitors);

        modelBuilder
        .Entity<Floor>()
        .HasMany(x => x.Rooms)
        .WithOne(x => x.Floor);

        modelBuilder
        .Entity<Floor>()
        .HasOne(x => x.Maid)
        .WithOne(x => x.Floor)
        .HasForeignKey<Maid>(x => x.FloorId);


        modelBuilder
        .Entity<Floor>()
        .HasIndex(x => x.Level)
        .IsUnique();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Warden> Wardens { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Maid> Maids { get; set; }
    public DbSet<Doorkeeper> Doorkeepers { get; set; }
    public DbSet<Janitor> Janitors { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Malfunction> Malfunctions { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Room> Rooms { get; set; }
}
