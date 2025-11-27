using CarWash.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarWash.Application.Interfaces;

public interface IOrderService
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
}