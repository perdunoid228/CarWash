using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CarWash.Application.Interfaces;
using CarWash.Core.Entities;
using CarWash.Infrastructure.Contexts;

namespace CarWash.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationContext _context;
    private readonly ILogger<OrderService> _logger;

    public OrderService(ApplicationContext context, ILogger<OrderService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Order>> GetAllOrdersAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<Order> CreateOrderAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task<Order> UpdateOrderAsync(Order order)
    {
        _context.Entry(order).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return order;
    }

    public async Task DeleteOrderAsync(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}