using Microsoft.EntityFrameworkCore;

namespace DataBaseCorrelations.Models;

public interface IConfigure
{
    void Configure(ModelBuilder modelBuilder);
}