using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Models;

public class UserClass : IConfigure
{
    public Guid Id { get; set; }
    public string Name { get; set; }=String.Empty;
    // public List<UserClass> Friends { get; set; } = new List<UserClass>();
    public List<UserToItem> Items { get; set; } = new List<UserToItem>();
    public void Configure(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<UserClass>();
        entity.HasKey(y => y.Id);

        entity.HasMany(x => x.Items).WithOne(x => x.User);
    }
}