using Microsoft.EntityFrameworkCore;
using WisdomPetMedicine.Services;

namespace WisdomPetMedicine.DataAccess;
public class WpmOutDbContext(IDatabasePathService databasePathService) : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Inspection> Inspections { get; set; }

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

public class Inspection
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public DateTime InspectionDate { get; set; } = DateTime.UtcNow;
    public double? Lat { get; set; }
    public double? Lon { get; set; }
    public List<InspectionItem> Items { get; set; } = new();
}

public class InspectionItem
{
    public int Id { get; set; }
    public int InspectionId { get; set; }
    public byte[] Media { get; set; }
    public InspectionType Type { get; set; }
    public Inspection Inspection { get; set; }
}

public enum InspectionType
{
    Photo
}