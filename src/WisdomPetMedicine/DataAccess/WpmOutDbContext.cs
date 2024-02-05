using Microsoft.EntityFrameworkCore;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.DataAccess;
public class WpmOutDbContext(IDatabasePathService databasePathService) : DbContext
{
    public DbSet<SaleItem> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={databasePathService.Get("wpm.db")}";
        optionsBuilder.UseSqlite(connectionString);
    }
}

public record SaleItem(int ClientId, 
    int ProductId, int Quantity, decimal Price)
{
    public int Id { get; set; }
}