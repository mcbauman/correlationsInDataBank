using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Models;

public class UserToItem : IConfigure
{
    public Guid Id { get; set; }
    public UserClass User { get; set; }
    public ItemClass Item { get; set; }
    public void Configure(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<UserToItem>();
        entity.HasKey(x => x.Id);

        entity.HasOne(x => x.User).WithMany(x => x.Items);
        entity.HasOne(x => x.Item).WithMany(x => x.UserToItems);
    }
}