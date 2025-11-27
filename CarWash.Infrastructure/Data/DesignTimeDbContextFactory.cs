using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarWash.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarWashDbContext>
{
    public CarWashDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarWashDbContext>();
        optionsBuilder.UseSqlite("Data Source=carwash.db");
        return new CarWashDbContext(optionsBuilder.Options);
    }
}
