using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Models;

public class ItemClass : IConfigure
{
    public Guid Id { get; set; }
    public string Name { get; set; }=String.Empty;
    public List<UserToItem> UserToItems { get; set; } = new();

    public void Configure(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<ItemClass>();
        entity.HasKey(x => x.Id);

        entity.HasMany(x => x.UserToItems).WithOne(x => x.Item);
    }
}