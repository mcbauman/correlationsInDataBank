using DataBaseCorrelations.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }
    public DbSet<UserClass> User { get; set; }
    public DbSet<ItemClass> Item { get; set; }
    public DbSet<UserToItem> UserToItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        typeof(ApplicationDbContext).Assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && typeof(IConfigure).IsAssignableFrom(x))
            .Select(x => (IConfigure) Activator.CreateInstance(x))
            .ToList()
            .ForEach(x => x.Configure(modelBuilder));
    }
}