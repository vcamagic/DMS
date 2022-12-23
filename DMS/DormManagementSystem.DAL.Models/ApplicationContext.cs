
using System.Diagnostics.CodeAnalysis;
using DormManagementSystem.DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.DAL.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext([NotNullAttribute] DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Account>()
        .HasIndex(x => x.Email)
        .IsUnique();

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
        .Entity<Claim>(x =>
        {
            x
            .HasOne(x => x.Account)
            .WithMany(x => x.Claims)
            .HasForeignKey(x => x.AccountId);
        });

        modelBuilder.Entity<Warden>().ToTable("Wardens");
        modelBuilder.Entity<Student>().ToTable("Students");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Janitor>().ToTable("Janitors");
        modelBuilder.Entity<Maid>().ToTable("Maids");
        modelBuilder.Entity<Doorkeeper>().ToTable("Doorkeepers");


        modelBuilder
        .Entity<Employee>()
        .HasMany(x => x.Shifts)
        .WithMany(x => x.Employees);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Warden> Wardens { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Maid> Maids { get; set; }
    public DbSet<Doorkeeper> Doorkeepers { get; set; }
    public DbSet<Janitor> Janitors { get; set; }
    public DbSet<Shift> Shifts { get; set; }
}
