using CarWash.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Application.Interfaces;

public interface IServiceService
{
    Task<List<Service>> GetAllServicesAsync();
    Task<Service> GetServiceByIdAsync(int id);
    Task<Service> CreateServiceAsync(Service service);
    Task<Service> UpdateServiceAsync(Service service);
    Task DeleteServiceAsync(int id);
}