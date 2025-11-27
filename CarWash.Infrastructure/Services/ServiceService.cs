using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CarWash.Application.Interfaces;
using CarWash.Core.Entities;
using CarWash.Infrastructure.Contexts;

namespace CarWash.Infrastructure.Services;

public class ServiceService : IServiceService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<ServiceService> _logger;

    public ServiceService(ApplicationContext context, ILogger<ServiceService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Service>> GetAllServicesAsync()
    {
        return await _context.Services.ToListAsync();
    }

    public async Task<Service> GetServiceByIdAsync(int id)
    {
        return await _context.Services.FindAsync(id);
    }

    public async Task<Service> CreateServiceAsync(Service service)
    {
        _context.Services.Add(service);
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task<Service> UpdateServiceAsync(Service service)
    {
        _context.Entry(service).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return service;
    }

    public async Task DeleteServiceAsync(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service != null)
        {
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
        }
    }
}