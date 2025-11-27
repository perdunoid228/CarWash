using CarWash.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Application.Interfaces;

public interface ICarService
{
    Task<List<Car>> GetAllCarsAsync();
    Task<Car> GetCarByIdAsync(int id);
    Task<Car> CreateCarAsync(Car car);
    Task<Car> UpdateCarAsync(Car car);
    Task DeleteCarAsync(int id);
}