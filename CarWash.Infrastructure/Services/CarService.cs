using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CarWash.Application.Interfaces;
using CarWash.Core.Entities;
using CarWash.Infrastructure.Contexts;

namespace CarWash.Infrastructure.Services;

public class CarService : ICarService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<CarService> _logger;

    public CarService(ApplicationContext context, ILogger<CarService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Car>> GetAllCarsAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Car> GetCarByIdAsync(int id)
    {
        return await _context.Cars.FindAsync(id);
    }

    public async Task<Car> CreateCarAsync(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task<Car> UpdateCarAsync(Car car)
    {
        _context.Entry(car).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return car;
    }

    public async Task DeleteCarAsync(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
    }
}