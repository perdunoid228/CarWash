using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarWash.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarWashDbContext>
{
    public CarWashDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarWashDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=carwash_db;Username=postgres;Password=postgres");

        return new CarWashDbContext(optionsBuilder.Options);
    }
}
