using CarWash.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Infrastructure.Data;

public class CarWashDbContext : DbContext
{
    public CarWashDbContext(DbContextOptions<CarWashDbContext> options)
        : base(options) { }

    public DbSet<Client> Clients => Set<Client>();
}
