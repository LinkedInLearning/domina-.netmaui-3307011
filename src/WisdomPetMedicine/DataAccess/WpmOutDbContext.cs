using Microsoft.EntityFrameworkCore;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.DataAccess;
public class WpmOutDbContext(IDatabasePathService databasePathService) : DbContext
{
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = $"Filename={databasePathService.Get("wpm.db")}";
        optionsBuilder.UseSqlite(connectionString);
    }
}

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public List<OrderItem> Items { get; set; } = new();
    public decimal Total { get; set; }
    public byte[] Signature { get; set; }
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Order Order { get; set; }
}