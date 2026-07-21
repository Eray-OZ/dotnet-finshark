using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace api.Data;


public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions options) : base(options) {}

    
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }


}
