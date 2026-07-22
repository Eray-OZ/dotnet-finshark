using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.IO.Compression;

namespace api.Data;


public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }


    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }



    // REGISTER
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Portfolio
        builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));
        builder.Entity<Portfolio>()
        .HasOne(u => u.AppUser)
        .WithMany(u => u.Portfolios)
        .HasForeignKey(p => p.AppUserId);

        builder.Entity<Portfolio>()
        .HasOne(u => u.Stock)
        .WithMany(u => u.Portfolios)
        .HasForeignKey(p => p.StockId);
        // Portfolio


        List<IdentityRole> roles = new List<IdentityRole>
        {
        new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Name = "User",
            NormalizedName = "USER"
        },
        };
        builder.Entity<IdentityRole>().HasData(roles);
    }
    // REGISTER

}
