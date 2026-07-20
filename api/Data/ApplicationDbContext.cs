using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) {}

    
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }


}
