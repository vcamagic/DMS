
using System.Diagnostics.CodeAnalysis;
using DormManagementSystem.DAL.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DormManagementSystem.DAL.Models;

public class ApplicationContext : DbContext
{
    public ApplicationContext([NotNullAttribute] DbContextOptions options): base(options)
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
        .Entity<Claim>(x => 
        {
            x
            .HasKey(x => new { x.ClaimTypeId, x.AccountId });

            x        
            .HasOne(x => x.Account)
            .WithMany(x => x.Claims)
            .HasForeignKey(x => x.AccountId);

        });

        modelBuilder
        .Entity<ClaimType>()
        .HasData(
            new ClaimType()
            {
                Id = Guid.NewGuid(),
                Name = "Role",
                Value = "Administrator"
            },
            new ClaimType()
            {
                Id = Guid.NewGuid(),
                Name = "Role",
                Value = "Warden"
            },
            new ClaimType()
            {
                Id = Guid.NewGuid(),
                Name = "Role",
                Value = "Maid"
            },
            new ClaimType()
            {
                Id = Guid.NewGuid(),
                Name = "Role",
                Value = "Doorkeeper"
            },
            new ClaimType()
            {
                Id = Guid.NewGuid(),
                Name = "Role",
                Value = "Janitor"
            },
            new ClaimType()
            {
                Id = Guid.NewGuid(),
                Name = "Role",
                Value = "Student"
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ClaimType> ClaimTypes { get; set; }
    public DbSet<Claim> Claims { get; set; }
}
