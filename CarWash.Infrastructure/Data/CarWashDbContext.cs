using CarWash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Infrastructure.Data;

public class CarWashDbContext : DbContext
{
    public CarWashDbContext(DbContextOptions<CarWashDbContext> options)
        : base(options) { }

    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderService> OrderServices => Set<OrderService>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(200);
            entity.Property(c => c.Phone).IsRequired().HasMaxLength(20);
        });
        
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Brand).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Model).IsRequired().HasMaxLength(100);
            entity.Property(c => c.LicensePlate).IsRequired().HasMaxLength(20);
            
            entity.HasOne(c => c.Client)
                  .WithMany(cl => cl.Cars)
                  .HasForeignKey(c => c.ClientId);
        });
        
        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(200);
            entity.Property(s => s.Description).HasMaxLength(500);
            entity.Property(s => s.Price).HasColumnType("decimal(18,2)");
        });
        
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            entity.Property(o => o.Status).HasConversion<string>();
            
            entity.HasOne(o => o.Client)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(o => o.ClientId);
                  
            entity.HasOne(o => o.Car)
                  .WithMany(c => c.Orders)
                  .HasForeignKey(o => o.CarId);
        });
        
        modelBuilder.Entity<OrderService>(entity =>
        {
            entity.HasKey(os => os.Id);
            
            entity.HasOne(os => os.Order)
                  .WithMany(o => o.OrderServices)
                  .HasForeignKey(os => os.OrderId);
                  
            entity.HasOne(os => os.Service)
                  .WithMany(s => s.OrderServices)
                  .HasForeignKey(os => os.ServiceId);
        });
    }
}